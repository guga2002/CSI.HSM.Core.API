using AutoMapper;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Notification.Service
{
    public class StaffNotificationService:GenericService<StafNotificationDto,StafNotificationResponseDto,long,StaffNotification>, IStaffNotificationService
    {
        public StaffNotificationService(IMapper mapper,
            IGenericRepository<StaffNotification> repos,
            ILogger<GenericService<StafNotificationDto,StafNotificationResponseDto, long, StaffNotification>> logger)
            : base(mapper, repos, logger)
        {
        }
    }
}
