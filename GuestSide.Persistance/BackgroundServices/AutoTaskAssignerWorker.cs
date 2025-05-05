using Domain.Core.Data;
using Domain.Core.Entities.Staff;
using Domain.Core.Entities.Task;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistance.BackgroundServices;

public class AutoTaskAssignerWorker : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<AutoTaskAssignerWorker> _logger;
    private Timer _timer;
    private bool _isRunning = false;

    public AutoTaskAssignerWorker(IServiceProvider serviceProvider, ILogger<AutoTaskAssignerWorker> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTaskAssignerWorker started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(15));
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync()
    {
        if (_isRunning) return;
        _isRunning = true;

        try
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<CoreSideDb>();

            var unassignedTasks = await db.Tasks
                .Include(t => t.TaskToStaff)
                .Where(t => !t.IsCompleted && t.TaskToStaff == null)//yvela  taskis wamogeba romlebic araris mibmuli
                .ToListAsync();

            var activeStaffs = await db.Staffs
                .Where(s => s.IsActive)
                .ToListAsync();

            foreach (var task in unassignedTasks)
            {
                var itemId = task.TaskItems?.Select(i => i.Item).FirstOrDefault();
                if (itemId is not null)
                {
                    var category = db.ItemCategoryToStaffCategories.FirstOrDefault(i => i.ItemCategoryId == itemId.ItemCategoryId);

                    var staffWithLeastTasks = activeStaffs
                        .Where(i => i.StaffCategoryId == category?.StaffCategoryId)
                        .Select(staff => new
                        {
                            Staff = staff,
                            ActiveTaskCount = db.TaskToStaffs.Count(t => t.AssignedBy == staff.Id && !t.IsCompleted)
                        })
                        .OrderBy(x => x.ActiveTaskCount)
                        .FirstOrDefault();

                    if (staffWithLeastTasks == null)
                    {
                        _logger.LogWarning("No active staff available to assign task {0}.", task.Id);
                        continue;
                    }

                    var newAssignment = new TaskToStaff
                    {
                        TaskId = task.Id,
                        AssignedBy = staffWithLeastTasks.Staff.Id,
                        StartDate = DateTime.UtcNow,
                        IsCompleted = false,
                        StatusId = db.TaskStatuses.FirstOrDefault()?.Id ?? 1,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true,
                        LanguageCode = "En",
                        UpdatedAt = DateTime.UtcNow,
                    };

                    db.TaskToStaffs.Add(newAssignment);

                    db.TaskLogs.Add(new TaskLogs
                    {
                        TaskId = task.Id,
                        Action = "AutoAssigned",
                        PerformedBy = "System",
                        Notes = $"Assigned to staff ID {staffWithLeastTasks.Staff.Id}",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true,
                        LanguageCode = "En",
                        UpdatedAt = DateTime.UtcNow,
                    });

                    _logger.LogInformation("Task {0} assigned to staff {1}", task.Id, staffWithLeastTasks.Staff.Id);
                }
            }

            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during AutoTaskAssignerWorker execution.");
        }
        finally
        {
            _isRunning = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTaskAssignerWorker stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose() => _timer?.Dispose();
}
