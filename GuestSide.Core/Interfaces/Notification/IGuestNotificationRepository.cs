using Core.Core.Entities.Notification;
using Core.Core.Interfaces.AbstractInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Core.Interfaces.Notification
{
    public interface IGuestNotificationRepository : IGenericRepository<GuestNotification>
    {
        Task<GuestNotification> MarkGuestNotificationAsRead(long GuestId, long NotificationId, bool unread = false);
        Task<IEnumerable<GuestNotification>> GetNotificationsByGuestId(long GuestId);
        //add another method
    }
}
