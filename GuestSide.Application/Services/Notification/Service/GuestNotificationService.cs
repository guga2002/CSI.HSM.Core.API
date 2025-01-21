using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Notification.Service;

public class GuestNotificationService : GenericService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>, IGuestNotificationService
{
    public GuestNotificationService(IMapper mapper, 
        IGenericRepository<GuestNotification> repository,
        ILogger<GenericService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>> logger, 
        IAdditionalFeaturesRepository<GuestNotification> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
