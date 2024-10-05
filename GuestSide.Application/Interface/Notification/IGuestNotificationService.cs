using GuestSide.Application.DTOs.Notification;
using GuestSide.Core.Entities.Notification;

namespace GuestSide.Application.Interface.Notification
{
    public interface IGuestNotificationService:IService<GuestNotificationDto,long,GuestNotification>
    {
    }
}
