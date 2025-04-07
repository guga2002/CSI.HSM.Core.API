using Core.Core.Data;
using Core.Core.Entities.Task;
using Core.Core.Entities.Notification;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Core.Core.Entities.Item;

namespace Core.Persistance.BackgroundServices;

public class GuestCheckOutFinalizerWorker : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<GuestCheckOutFinalizerWorker> _logger;
    private Timer? _timer;
    private bool _isRunning = false;

    public GuestCheckOutFinalizerWorker(IServiceProvider serviceProvider, ILogger<GuestCheckOutFinalizerWorker> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("GuestCheckOutFinalizerWorker started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync()
    {
        if (_isRunning) return;
        _isRunning = true;

        try
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GuestSideDb>();
            var now = DateTime.UtcNow;

            var guestsToFinalize = await db.Guests
                .Include(g => g.Room)
                .Where(g => g.CheckOutDate != null && g.CheckOutDate < now && !g.HasBeenFinalized)
                .ToListAsync();

            foreach (var guest in guestsToFinalize)
            {
                if (guest.Room != null)
                {
                    guest.Room.IsAvailable = true;
                }

                var cart = new Cart
                {
                    CreatedAt = now,
                    GuestId = guest.Id,
                    IsActive = false,
                    IsComplete = false,
                    LanguageCode = guest.LanguageCode,
                    UpdatedAt = now,
                    WhatWillRobotSay = guest.WhatWillRobotSay,
                };
                db.Carts.Add(cart);
                await db.SaveChangesAsync();

                var cleaningTask = new Tasks
                {
                    Title = $"Room Cleaning - Room {guest.Room?.RoomNumber}",
                    Description = $"Auto-generated cleaning task for room {guest.Room?.RoomNumber} after guest {guest.FirstName} {guest.LastName} checked out.",
                    CartId = cart.Id,
                    DueDate = now.AddHours(2),
                    Status = Core.Entities.Enums.StatusEnum.Pending,
                    Priority = Core.Entities.Enums.PriorityEnum.Medium,
                    Note = "Auto-cleaning task after guest checkout",
                    IsCompleted = false
                };
                db.Tasks.Add(cleaningTask);

                var notification = new Notifications
                {
                    NotificationDate = now,
                    CreatedAt = now,
                    Title = "Thank you for staying with us!",
                    LanguageCode = "En",
                    IsSent = false,
                    UpdatedAt = now,
                    SentDate = now,
                    IsActive = true,
                    NotificationType = Core.Entities.Enums.NotificationType.Reminder,
                    PriorityLevel = Core.Entities.Enums.PriorityEnum.Low,
                    Message = "We hope you enjoyed your stay. Please leave feedback or contact support if needed."
                };
                await db.Notifications.AddAsync(notification);
                await db.SaveChangesAsync();

                var guestNotification = new GuestNotification
                {
                    GuestId = guest.Id,
                    CreatedAt = now,
                    IsActive = true,
                    IsImportant = true,
                    IsRead = false,
                    LanguageCode = "En",
                    ReadTime = null,
                    SentTime = now,
                    UpdatedAt = now,
                    NotificationId = notification.Id
                };
                await db.GuestNotifications.AddAsync(guestNotification);

                guest.HasBeenFinalized = true;
                guest.IsActive = false;

                _logger.LogInformation("Finalized guest checkout for GuestId={0}, Room={1}", guest.Id, guest.Room?.RoomNumber ?? 0);
            }

            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while finalizing guest checkouts.");
        }
        finally
        {
            _isRunning = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("GuestCheckOutFinalizerWorker stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose() => _timer?.Dispose();
}
