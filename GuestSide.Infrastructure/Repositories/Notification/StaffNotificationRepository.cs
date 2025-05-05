using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Notification;
using Domain.Core.Interfaces.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure.Repositories.Notification
{
    public class StaffNotificationRepository : GenericRepository<StaffNotification>, IStaffNotificationRepository
    {
        public StaffNotificationRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<StaffNotification> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        #region Mark Notification as Read/Unread
        public async Task<StaffNotification> MarkStaffNotificationAsRead(long staffId, long notificationId, bool unread = false)
        {
            var notification = await DbSet.FirstOrDefaultAsync(io => io.StaffId == staffId && io.NotificationId == notificationId);

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

        #region Get All Notifications for Staff
        public async Task<IEnumerable<StaffNotification>> GetUnreadNotificationsByStaffId(long staffId)
        {
            return await DbSet
                .Include(io => io.Notifications)
                .Where(io => io.StaffId == staffId && !io.IsRead)
                .OrderByDescending(io => io.SentTime)
                .ToListAsync();
        }
        #endregion

        #region Get Important Notifications for Staff
        public async Task<IEnumerable<StaffNotification>> GetImportantNotificationsByStaffId(long staffId)
        {
            return await DbSet
                .Include(io => io.Notifications)
                .Where(io => io.StaffId == staffId && io.IsImportant)
                .OrderByDescending(io => io.SentTime)
                .ToListAsync();
        }
        #endregion

        #region Delete Staff Notification (Soft Delete)
        public async Task<bool> DeleteStaffNotification(long staffId, long notificationId)
        {
            var notification = await DbSet.FirstOrDefaultAsync(io => io.StaffId == staffId && io.NotificationId == notificationId);

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
        public override async Task<IEnumerable<StaffNotification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Include(io => io.StaffMember)
                .Include(io => io.Notifications)
                .Where(io => io.IsActive)
                .ToListAsync(cancellationToken);
        }
        #endregion

        #region Get Notification by ID (Overridden)
        public override async Task<StaffNotification> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Include(io => io.StaffMember)
                .Include(io => io.Notifications)
                .Where(io => io.IsActive && io.Id == long.Parse(id.ToString()))
                .FirstOrDefaultAsync(cancellationToken);
        }
        #endregion

        #region GetStaffNotifications
        public async Task<IEnumerable<StaffNotification>> GetStaffNotifications(long staffId)
        {
            return await DbSet
                .Include(io => io.Notifications)
                .Where(io => io.StaffId == staffId)
                .OrderByDescending(io => io.SentTime)
                .ToListAsync();
        }
        #endregion
    }
}
