using AutoMapper;
using GuestSide.Application.DTOs.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Notification.Service
{
    public class StaffNotificationService:GenericService<StafNotificationDto,long,StaffNotification>, IStaffNotificationService
    {
        public StaffNotificationService(IMapper mapper,
            IGenericRepository<StaffNotification> repos,
            ILogger<GenericService<StafNotificationDto, long, StaffNotification>> logger)
            : base(mapper, repos, logger)
        {
        }
    }
}
