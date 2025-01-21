using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Notification;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : CSIControllerBase<NotificationDto, NotificationResponseDto, long, Notifications>
{
    public NotificationController(IService<NotificationDto, NotificationResponseDto, long, Notifications> serviceProvider, IAdditionalFeatures<NotificationDto, NotificationResponseDto, long, Notifications> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
