using AutoMapper;
using GuestSide.Application.DTOs.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Notification.Service
{
    public class NotificationService:GenericService<NotificationDto,long,Notifications>,INotificationService
    {
        public NotificationService(IMapper mapper,
            IGenericRepository<Notifications> repos,
            ILogger<GenericService<NotificationDto, long, Notifications>> logger)
            : base(mapper, repos, logger)
        {
        }
    }
}
