using AutoMapper;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.Notification;
using Core.Application.Services;
using Core.Core.Entities.Notification;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Notification.Service;

public class StaffNotificationService : GenericService<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>, IStaffNotificationService
{
    public StaffNotificationService(IMapper mapper,
        IGenericRepository<StaffNotification> repository,
        ILogger<GenericService<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>> logger,
        IAdditionalFeaturesRepository<StaffNotification> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
