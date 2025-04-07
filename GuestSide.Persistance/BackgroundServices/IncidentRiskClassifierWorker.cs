using Core.Core.Data;
using Core.Core.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.BackgroundServices;

public class IncidentRiskClassifierWorker : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<IncidentRiskClassifierWorker> _logger;
    private Timer _timer;
    private bool _isProcessing = false;

    public IncidentRiskClassifierWorker(IServiceProvider serviceProvider, ILogger<IncidentRiskClassifierWorker> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("IncidentRiskClassifierWorker started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromHours(6));
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
            var criticalThreshold = now.AddDays(-7);

            var flaggedStaff =await  db.StaffIncidents
                .Where(i =>
                    (i.Severity == PriorityEnum.High || i.RequiresImmediateAction) &&
                    i.CreatedAt >= criticalThreshold)
                .GroupBy(i => i.ReportedByStaffId)
                .Select(g => new
                {
                    StaffId = g.Key,
                    CriticalCount = g.Count(),
                    UrgentCount = g.Count(x => x.RequiresImmediateAction),
                    LastIncident = g.Max(x => x.CreatedAt)
                })
                .Where(x => x.CriticalCount >= 2 || x.UrgentCount > 0)
                .ToListAsync();

            foreach (var flagged in flaggedStaff)
            {
                _logger.LogWarning("Risk alert for staff {0}: {1} critical incidents in last 7 days. Last at {2}",
                    flagged.StaffId, flagged.CriticalCount, flagged.LastIncident.ToLocalTime());
                //inform  person or manager about it:// todo guga
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "IncidentRiskClassifierWorker failed.");
        }
        finally
        {
            _isProcessing = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("IncidentRiskClassifierWorker stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose() => _timer?.Dispose();
}
