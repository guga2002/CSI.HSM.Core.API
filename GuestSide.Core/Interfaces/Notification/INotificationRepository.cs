using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Notification;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Notification;

public interface INotificationRepository : IGenericRepository<Notifications>
{
    Task<IEnumerable<Notifications>> GetUnsentNotifications();

    Task<IEnumerable<Notifications>> GetNotificationsByPriority(PriorityEnum priority);

    Task<bool> MarkNotificationAsSent(long notificationId);

    Task<IEnumerable<Notifications>> GetNotificationsByDateRange(DateTime start, DateTime end);

    Task<IEnumerable<Notifications>> GetLatestNotifications(int count);
}