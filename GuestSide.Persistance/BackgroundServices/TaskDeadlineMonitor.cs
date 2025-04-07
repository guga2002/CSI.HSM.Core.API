using Core.Core.Data;
using Core.Persistance.MailServices;
using Core.Persistance.PtmsCsi;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.BackgroundServices;

public class TaskDeadlineMonitor : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<TaskDeadlineMonitor> _logger;
    private Timer _timer;
    private bool _isProcessing = false;

    public TaskDeadlineMonitor(IServiceProvider serviceProvider, ILogger<TaskDeadlineMonitor> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("TaskDeadlineMonitor started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync()
    {
        if (_isProcessing) return;
        _isProcessing = true;

        try
        {
            var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GuestSideDb>();
            var smtpService = scope.ServiceProvider.GetRequiredService<SmtpService>();
            var templateGateway = scope.ServiceProvider.GetRequiredService<ITemplateGatewayService>();
            var httpContextAccessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();

            if (httpContextAccessor.HttpContext == null)
                httpContextAccessor.HttpContext = new DefaultHttpContext();

            if (httpContextAccessor.HttpContext.Request.Headers.TryGetValue("X-Hotel-Id", out var hotelId))
            {
                var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                var connection = config.GetConnectionString(hotelId!);
                if (connection != null)
                    httpContextAccessor.HttpContext.Items["ConnectionString"] = connection;
            }
            DateTime now = DateTime.UtcNow;
            DateTime approachingThreshold = now.AddHours(1);
            var targets = db.Tasks
                .Where(t => !t.IsCompleted && t.DueDate != null)
                .Select(t => new
                {
                    t.Id,
                    t.Title,
                    t.DueDate,
                    t.Note,
                    t.Priority,
                    Staff = t.TaskToStaff
                })
                .Where(x => x.DueDate < approachingThreshold && x.DueDate > now || x.DueDate < now)
                .ToList();

            if (targets.Any())
            {
                string rows = string.Join("", targets.Select(task => $@"
<tr>
    <td style='padding: 10px; border: 1px solid #ddd;'>{task.Title}</td>
    <td style='padding: 10px; border: 1px solid #ddd;'>{task.DueDate?.ToLocalTime():yyyy-MM-dd HH:mm}</td>
    <td style='padding: 10px; border: 1px solid #ddd;'>{(task.DueDate < now ? "⚠️ Overdue" : "⏳ Approaching")}</td>
</tr>
"));
                var rendered = await templateGateway.RenderTemplateAsFileAsync(new()
                {
                    TemplateKey = "TaskDeadlineAlert",
                    Language = "En",
                    Data = new Dictionary<string, string>
                    {
                    { "ITEM_ROWS", rows }
                    }
                });
                var html = System.Text.Encoding.UTF8.GetString(rendered.File);
                smtpService.SendMessage("guram.apkhazava908@ens.tsu.ge", "Task Deadline Alert", html);
                smtpService.SendMessage("raisa.badalova132@ens.tsu.ge", "Task Deadline Alert", html);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "TaskDeadlineMonitor error.");
        }
        finally
        {
            _isProcessing = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("TaskDeadlineMonitor stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose() => _timer?.Dispose();
}
