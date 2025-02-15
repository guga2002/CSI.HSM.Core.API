using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Notification;

namespace Core.Application.Interface.Notification;

public interface INotificationService : IService<NotificationDto, NotificationResponseDto, long, Notifications>,
    IAdditionalFeatures<NotificationDto, NotificationResponseDto, long, Notifications>
{
}
