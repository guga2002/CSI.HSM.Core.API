using AutoMapper;
using GuestSide.Application.DTOs.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Notification.Service
{
    public class GuestNotificationService:GenericService<GuestNotificationDto,long,GuestNotification>,IGuestNotificationService
    {
        public GuestNotificationService(IMapper mapper, 
            IGenericRepository<GuestNotification> repos, 
            ILogger<GenericService<GuestNotificationDto, long, GuestNotification>> logger)
            :base(mapper, repos, logger)
        {
        }
    }
}
