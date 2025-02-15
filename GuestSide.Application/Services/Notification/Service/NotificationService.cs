using AutoMapper;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.Notification;
using Core.Application.Services;
using Core.Core.Entities.Notification;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Notification.Service;

public class NotificationService : GenericService<NotificationDto, NotificationResponseDto, long, Notifications>, INotificationService
{
    public NotificationService(IMapper mapper,
        IGenericRepository<Notifications> repository,
        ILogger<GenericService<NotificationDto, NotificationResponseDto, long, Notifications>> logger,
        IAdditionalFeaturesRepository<Notifications> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
