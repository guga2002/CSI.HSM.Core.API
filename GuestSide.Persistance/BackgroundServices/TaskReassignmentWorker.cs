using Core.Core.Data;
using Core.Core.Entities.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace Core.Persistance.BackgroundServices;

public class TaskReassignmentWorker : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<TaskReassignmentWorker> _logger;
    private Timer _timer;
    private bool _isProcessing = false;

    public TaskReassignmentWorker(IServiceProvider serviceProvider, ILogger<TaskReassignmentWorker> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("TaskReassignmentWorker started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync()
    {
        if (_isProcessing) return;
        _isProcessing = true;

        try
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GuestSideDb>();
            var now = DateTime.UtcNow;
            var overdueTasks =await db.TaskToStaffs.
                Include(i=>i.Task).
                ThenInclude(i=>i.TaskItems)
                .Where(tts => !tts.IsCompleted && tts.Task.DueDate < now && tts.EndDate == null)
                .ToListAsync();

            foreach (var taskToStaff in overdueTasks)
            {

                var taskId = taskToStaff.TaskId;
                var taskItemId = taskToStaff.Task.TaskItems?.Select(i => i.Item.ItemCategoryId).FirstOrDefault();
                var itemCategory =await db.ItemCategoryToStaffCategories.FirstOrDefaultAsync(i => i.ItemCategoryId == taskItemId);

                var currentStaffId = taskToStaff.AssignedBy;
                if (itemCategory is not null)
                {
                    var allStaff = db.Staffs.Where(s => s.IsActive && s.StaffCategoryId == itemCategory.StaffCategoryId).ToList();
                    var candidates = allStaff
                        .Select(staff => new
                        {
                            Staff = staff,
                            ActiveTaskCount = db.TaskToStaffs.Count(tts => tts.AssignedBy == staff.Id && !tts.IsCompleted)
                        })
                        .Where(x => x.ActiveTaskCount < 3 && x.Staff.Id != currentStaffId)
                        .OrderBy(x => x.ActiveTaskCount)
                        .ToList();

                    var newAssignee = candidates.FirstOrDefault();
                    if (newAssignee == null)
                    {
                        _logger.LogWarning("No available staff found for task {TaskId}", taskId);
                        continue;
                    }

                    taskToStaff.AssignedBy = newAssignee.Staff.Id;
                    taskToStaff.StartDate = DateTime.UtcNow;
                    taskToStaff.EndDate = null;
                    taskToStaff.IsCompleted = false;
                    taskToStaff.UpdatedAt = DateTime.UtcNow;

                    db.TaskLogs.Add(new TaskLogs
                    {
                        TaskId = taskId,
                        Action = "AutoReassigned",
                        PerformedBy = "System",
                        Notes = $"Reassigned from staff {currentStaffId} to {newAssignee.Staff.Id} due to inactivity or overload.",
                        UpdatedAt = DateTime.UtcNow,
                    });

                    await db.SaveChangesAsync();
                    _logger.LogInformation("Task {TaskId} reassigned to staff {StaffId}", taskId, newAssignee.Staff.Id);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "TaskReassignmentWorker failed.");
        }
        finally
        {
            _isProcessing = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("TaskReassignmentWorker stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose() => _timer?.Dispose();
}
