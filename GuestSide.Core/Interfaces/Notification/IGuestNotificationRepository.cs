using Core.Core.Entities.Notification;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Notification
{
    public interface IGuestNotificationRepository : IGenericRepository<GuestNotification>
    {
        Task<GuestNotification> MarkGuestNotificationAsRead(long guestId, long notificationId, bool unread = false);
        Task<IEnumerable<GuestNotification>> GetNotificationsByGuestId(long guestId);
        Task<IEnumerable<GuestNotification>> GetUnreadNotificationsByGuestId(long guestId);
        Task<IEnumerable<GuestNotification>> GetImportantNotificationsByGuestId(long guestId);
        Task<bool> DeleteGuestNotification(long guestId, long notificationId);
    }
}