using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Notification;

namespace Core.Application.Interface.Notification;

public interface IStaffNotificationService : IService<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>,
    IAdditionalFeatures<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>
{
}
