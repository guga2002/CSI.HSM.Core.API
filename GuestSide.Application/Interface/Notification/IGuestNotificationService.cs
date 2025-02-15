using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Notification;

namespace Core.Application.Interface.Notification;

public interface IGuestNotificationService : IService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>,
    IAdditionalFeatures<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>
{
    Task<GuestNotificationResponseDto> MarkGuestNotificationAsRead(long GuestId, long NotificationId, bool unread = false);
    Task<IEnumerable<GuestNotificationResponseDto>> GetNotificationsByGuestId(long GuestId);
}
