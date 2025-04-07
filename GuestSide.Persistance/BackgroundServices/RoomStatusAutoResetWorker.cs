using Core.Core.Data;
using Core.Core.Entities.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.BackgroundServices;

public class RoomStatusAutoResetWorker : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RoomStatusAutoResetWorker> _logger;
    private Timer _timer;
    private bool _isProcessing = false;

    public RoomStatusAutoResetWorker(IServiceProvider serviceProvider, ILogger<RoomStatusAutoResetWorker> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("RoomStatusAutoResetWorker started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromHours(4));
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
            var roomsToReset = db.Rooms.
                Include(i=>i.Guests)
                .Where(r => !r.IsAvailable && r.Guests.All(g => g.CheckOutDate != null && g.CheckOutDate < now))
                .ToList();

            foreach (var room in roomsToReset)
            {
                room.IsAvailable = true;

                _logger.LogInformation("Room {0} (Floor {1}) reset to available.", room.RoomNumber, room.Floor);
            }

            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "RoomStatusAutoResetWorker failed.");
        }
        finally
        {
            _isProcessing = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("RoomStatusAutoResetWorker stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose() => _timer?.Dispose();
}
