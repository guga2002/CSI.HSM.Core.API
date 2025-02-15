using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Notification;

namespace Core.Application.Interface.Notification
{
    public interface IGuestNotificationService : IService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>,
        IAdditionalFeatures<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>
    {
        /// <summary>
        /// Mark a guest's notification as read/unread.
        /// </summary>
        Task<GuestNotificationResponseDto?> MarkGuestNotificationAsRead(long guestId, long notificationId, bool unread = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all notifications for a guest.
        /// </summary>
        Task<IEnumerable<GuestNotificationResponseDto>> GetNotificationsByGuestId(long guestId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get unread notifications for a guest.
        /// </summary>
        Task<IEnumerable<GuestNotificationResponseDto>> GetUnreadNotificationsByGuestId(long guestId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get important notifications for a guest.
        /// </summary>
        Task<IEnumerable<GuestNotificationResponseDto>> GetImportantNotificationsByGuestId(long guestId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a specific guest notification.
        /// </summary>
        Task<bool> DeleteGuestNotification(long guestId, long notificationId, CancellationToken cancellationToken = default);
    }
}