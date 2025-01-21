using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Notification
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffNotificationController : CSIControllerBase<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>
    {
        public StaffNotificationController(IService<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification> serviceProvider, IAdditionalFeatures<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification> additionalFeatures) : base(serviceProvider, additionalFeatures)
        {
        }
    }
}
