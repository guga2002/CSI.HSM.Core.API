using Core.Core.Data;
using Core.Core.Entities.Notification;
using Core.Core.Interfaces.Notification;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Notification
{
    public class NotificationRepository : GenericRepository<Notifications>, INotificationRepository
    {
        public NotificationRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Notifications> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        #region Get Unsent Notifications
        public async Task<IEnumerable<Notifications>> GetUnsentNotifications()
        {
            return await DbSet
                .Where(n => !n.IsSent)
                .OrderBy(n => n.NotificationDate)
                .ToListAsync();
        }
        #endregion

        #region Get Notifications by Priority
        public async Task<IEnumerable<Notifications>> GetNotificationsByPriority(NotificationPriority priority)
        {
            return await DbSet
                .Where(n => n.PriorityLevel == priority)
                .OrderByDescending(n => n.NotificationDate)
                .ToListAsync();
        }
        #endregion

        #region  Mark Notification as Sent
        public async Task<bool> MarkNotificationAsSent(long notificationId)
        {
            var notification = await DbSet.FindAsync(notificationId);
            if (notification == null) return false;

            notification.IsSent = true;
            notification.SentDate = DateTime.UtcNow;
            await Context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region  Get Notifications by Date Range
        public async Task<IEnumerable<Notifications>> GetNotificationsByDateRange(DateTime start, DateTime end)
        {
            return await DbSet
                .Where(n => n.NotificationDate >= start && n.NotificationDate <= end)
                .OrderByDescending(n => n.NotificationDate)
                .ToListAsync();
        }
        #endregion

        #region  Get Latest Notifications
        public async Task<IEnumerable<Notifications>> GetLatestNotifications(int count)
        {
            return await DbSet
                .OrderByDescending(n => n.NotificationDate)
                .Take(count)
                .ToListAsync();
        }
        #endregion
    }
}
