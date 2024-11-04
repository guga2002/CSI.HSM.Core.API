using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Core.Entities.Notification;

namespace GuestSide.Application.Interface.Notification
{
    public interface INotificationService:IService<NotificationDto,NotificationResponseDto,long,Notifications>
    {
    }
}
