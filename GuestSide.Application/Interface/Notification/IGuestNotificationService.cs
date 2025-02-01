using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Core.Entities.Notification;

namespace GuestSide.Application.Interface.Notification;

public interface IGuestNotificationService:IService<GuestNotificationDto,GuestNotificationResponseDto,long,GuestNotification>,
    IAdditionalFeatures<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>
{
    Task<GuestNotificationResponseDto> MarkGuestNotificationAsRead(long GuestId, long NotificationId, bool unread = false);
    Task<IEnumerable<GuestNotificationResponseDto>> GetNotificationsByGuestId(long GuestId);
}
