using GuestSide.Application.Interface.Notification;
using GuestSide.Application.Services.Notification.Service;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Infrastructure.Repositories.Notification;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Notification.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using GuestSide.Core.Entities.LogEntities;

namespace GuestSide.Application.Services.Notification.DI;

public static class NotificationDI
{
    public static void InjectNotification(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Notifications>, NotificationRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IService<NotificationDto,NotificationResponseDto, long, Notifications>, NotificationService>();
        services.AddScoped<IAdditionalFeatures<NotificationDto, NotificationResponseDto, long, Notifications>, NotificationService>();
        services.AddAutoMapper(typeof(NotificationMapper));
        services.AddScoped<IAdditionalFeaturesRepository<GuestNotification>, AdditionalFeaturesRepository<GuestNotification>>();
    }
}
