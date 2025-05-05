using Domain.Core.Data;
using Domain.Core.Entities.Item;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.BackgroundServices;

public class StaleCartCleanerWorker : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<StaleCartCleanerWorker> _logger;
    private Timer _timer;
    private bool _isProcessing = false;

    public StaleCartCleanerWorker(IServiceProvider serviceProvider, ILogger<StaleCartCleanerWorker> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("StaleCartCleanerWorker started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromHours(1));
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync()
    {
        if (_isProcessing) return;
        _isProcessing = true;

        try
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<CoreSideDb>();

            var cutoff = DateTime.UtcNow.AddHours(-24);

            var staleCarts = db.Carts
                .Where(c => !c.IsComplete && c.CreatedAt < cutoff)
                .ToList();

            if (!staleCarts.Any())
            {
                _logger.LogInformation("No stale carts found.");
                return;
            }

            foreach (var cart in staleCarts)
            {
                cart.IsComplete = true;
                _logger.LogInformation("Stale cart closed (ID: {0}, Guest: {1})", cart.Id, cart.GuestId);
            }

            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "StaleCartCleanerWorker failed.");
        }
        finally
        {
            _isProcessing = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("StaleCartCleanerWorker stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose() => _timer?.Dispose();
}
