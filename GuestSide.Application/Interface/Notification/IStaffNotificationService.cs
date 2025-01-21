using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Core.Entities.Notification;

namespace GuestSide.Application.Interface.Notification;

public interface IStaffNotificationService:IService<StafNotificationDto, StafNotificationResponseDto,long,StaffNotification>,
    IAdditionalFeatures<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>
{
}
