using Core.Core.Data;
using Core.Core.Entities.Notification;
using Core.Core.Interfaces.Notification;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Notification;

public class GuestNotificationRepository : GenericRepository<GuestNotification>, IGuestNotificationRepository
{
    public GuestNotificationRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<GuestNotification> logger)
        : base(context, redisCache, httpContextAccessor, logger)
    {
    }

    #region Mark Notification as Read/Unread
    public async Task<GuestNotification> MarkGuestNotificationAsRead(long guestId, long notificationId, bool unread = false)
    {
        var notification = await DbSet.FirstOrDefaultAsync(io => io.GuestId == guestId && io.NotificationId == notificationId);

        if (notification is not null)
        {
            notification.IsRead = !unread;
            notification.ReadTime = unread ? null : DateTime.UtcNow;
            await Context.SaveChangesAsync();
            return notification;
        }

        return null;
    }
    #endregion

    #region Get All Notifications for Guest
    public async Task<IEnumerable<GuestNotification>> GetNotificationsByGuestId(long guestId)
    {
        return await DbSet
            .Include(io => io.Guest)
            .Include(io => io.Notifications)
            .Where(io => io.GuestId == guestId)
            .OrderByDescending(io => io.SentTime)
            .ToListAsync();
    }
    #endregion

    #region Get Unread Notifications for Guest
    public async Task<IEnumerable<GuestNotification>> GetUnreadNotificationsByGuestId(long guestId)
    {
        return await DbSet
            .Include(io => io.Notifications)
            .Where(io => io.GuestId == guestId && !io.IsRead)
            .OrderByDescending(io => io.SentTime)
            .ToListAsync();
    }
    #endregion

    #region  Get Important Notifications for Guest
    public async Task<IEnumerable<GuestNotification>> GetImportantNotificationsByGuestId(long guestId)
    {
        return await DbSet
            .Include(io => io.Notifications)
            .Where(io => io.GuestId == guestId && io.IsImportant)
            .OrderByDescending(io => io.SentTime)
            .ToListAsync();
    }
    #endregion

    #region Delete Guest Notification (Soft Delete)
    public async Task<bool> DeleteGuestNotification(long guestId, long notificationId)
    {
        var notification = await DbSet.FirstOrDefaultAsync(io => io.GuestId == guestId && io.NotificationId == notificationId);

        if (notification != null)
        {
            notification.IsActive = false;  // Soft delete by marking inactive
            await Context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    #endregion

    #region Get All Notifications (Overridden)
    public override async Task<IEnumerable<GuestNotification>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(io => io.Guest)
            .Include(io => io.Notifications)
            .Where(io => io.IsActive)  // Only fetch active notifications
            .ToListAsync(cancellationToken);
    }
    #endregion

    #region  Get Notification by ID (Overridden)
    public override async Task<GuestNotification> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(io => io.Guest)
            .Include(io => io.Notifications)
            .Where(io => io.IsActive && io.Id == long.Parse(id.ToString()))
            .FirstOrDefaultAsync(cancellationToken);
    }
    #endregion
}
