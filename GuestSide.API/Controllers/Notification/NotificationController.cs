using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Notification;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Notification
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : CSIControllerBase<NotificationDto,long,Notifications>
    {
        public NotificationController(IService<NotificationDto, long, Notifications> service):base(service) { }
        
        
    }
}
