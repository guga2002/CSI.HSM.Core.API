using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Notification;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Notification
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestNotidicationController : CSIControllerBase<GuestNotificationDto,long,GuestNotification>
    {
        public GuestNotidicationController(IService<GuestNotificationDto, long, GuestNotification> service):base(service)
        {
        }

    }
}
