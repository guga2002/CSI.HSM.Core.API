using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Notification.Mapper;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Application.Interface.Notification;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Services.Notification.Service;
using Core.Infrastructure.Repositories.Notification;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Notification;
using Domain.Core.Entities.Notification;

namespace Core.Application.Services.Notification.DI;

public static class NotificationDI
{
    public static void InjectNotification(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Notifications>, NotificationRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IService<NotificationDto, NotificationResponseDto, long, Notifications>, NotificationService>();
        services.AddScoped<IAdditionalFeatures<NotificationDto, NotificationResponseDto, long, Notifications>, NotificationService>();
        services.AddAutoMapper(typeof(NotificationMapper));
        services.AddScoped<IAdditionalFeaturesRepository<GuestNotification>, AdditionalFeaturesRepository<GuestNotification>>();
    }
}
