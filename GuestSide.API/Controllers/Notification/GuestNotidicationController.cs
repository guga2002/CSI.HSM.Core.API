using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Notification;

[Route("api/[controller]")]
[ApiController]
public class GuestNotificationController : CSIControllerBase<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>
{
    public GuestNotificationController(IService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification> serviceProvider, IAdditionalFeatures<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
