using AutoMapper;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Notification.Service
{
    public class NotificationService:GenericService<NotificationDto,NotificationResponseDto,long,Notifications>,INotificationService
    {
        public NotificationService(IMapper mapper,
            IGenericRepository<Notifications> repos,
            ILogger<GenericService<NotificationDto,NotificationResponseDto, long, Notifications>> logger)
            : base(mapper, repos, logger)
        {
        }
    }
}
