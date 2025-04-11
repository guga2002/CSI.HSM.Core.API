using Domain.Core.Entities.Notification;
using Domain.Core.Interfaces.AbstractInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Notification
{
    public interface IStaffNotificationRepository : IGenericRepository<StaffNotification>
    {
        Task<StaffNotification> MarkStaffNotificationAsRead(long staffId, long notificationId, bool unread = false);
        Task<IEnumerable<StaffNotification>> GetUnreadNotificationsByStaffId(long staffId);
        Task<IEnumerable<StaffNotification>> GetImportantNotificationsByStaffId(long staffId);
        Task<bool> DeleteStaffNotification(long staffId, long notificationId);
        Task<IEnumerable<StaffNotification>> GetStaffNotifications(long staffId);
    }
}