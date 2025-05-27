using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Notification;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Services.Notification.Mapper;
using Core.Application.Services.Notification.Service;
using Common.Data.Entities.Notification;
using Common.Data.Interfaces.Notification;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Notification;
using Common.Data.Repositories.AbstractRepository;

namespace Core.Application.Services.Notification.DI;

public static class GuestNotificationDI
{
    public static void InjectGuestNotification(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<GuestNotification>, GuestNotificationRepository>();
        services.AddScoped<IGuestNotificationRepository, GuestNotificationRepository>();
        services.AddScoped<IGuestNotificationService, GuestNotificationService>();
        services.AddScoped<IService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>, GuestNotificationService>();
        services.AddScoped<IAdditionalFeatures<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>, GuestNotificationService>();
        services.AddAutoMapper(typeof(GuestNotificationMapper));
        services.AddScoped<IAdditionalFeaturesRepository<GuestNotification>, AdditionalFeaturesRepository<GuestNotification>>();
    }
}
