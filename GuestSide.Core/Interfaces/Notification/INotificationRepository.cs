using Core.Core.Entities.Notification;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Notification
{
    public interface INotificationRepository : IGenericRepository<Notifications>
    {
        Task<IEnumerable<Notifications>> GetUnsentNotifications();
        Task<IEnumerable<Notifications>> GetNotificationsByPriority(NotificationPriority priority);
        Task<bool> MarkNotificationAsSent(long notificationId);
        Task<IEnumerable<Notifications>> GetNotificationsByDateRange(DateTime start, DateTime end);
        Task<IEnumerable<Notifications>> GetLatestNotifications(int count);
    }
}