using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Enums;
using Core.Core.Entities.Notification;

namespace Core.Application.Interface.Notification
{
    public interface INotificationService : IService<NotificationDto, NotificationResponseDto, long, Notifications>,
        IAdditionalFeatures<NotificationDto, NotificationResponseDto, long, Notifications>
    {
        /// <summary>
        /// Get unsent notifications.
        /// </summary>
        Task<IEnumerable<NotificationResponseDto>> GetUnsentNotifications(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get notifications filtered by priority.
        /// </summary>
        Task<IEnumerable<NotificationResponseDto>> GetNotificationsByPriority(PriorityEnum priority, CancellationToken cancellationToken = default);

        /// <summary>
        /// Mark a notification as sent.
        /// </summary>
        Task<bool> MarkNotificationAsSent(long notificationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get notifications in a date range.
        /// </summary>
        Task<IEnumerable<NotificationResponseDto>> GetNotificationsByDateRange(DateTime start, DateTime end, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get latest notifications up to a specified count.
        /// </summary>
        Task<IEnumerable<NotificationResponseDto>> GetLatestNotifications(int count, CancellationToken cancellationToken = default);
    }
}