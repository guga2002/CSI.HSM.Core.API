using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Notification.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Interfaces.Notification;
using Core.Core.Entities.Notification;
using Core.Application.Interface.Notification;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Services.Notification.Service;
using Core.Infrastructure.Repositories.Notification;

namespace Core.Application.Services.Notification.DI;

public static class StaffNotificationDI
{
    public static void InjectStaffNotification(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<StaffNotification>, StaffNotificationRepository>();
        services.AddScoped<IStaffNotificationRepository, StaffNotificationRepository>();
        services.AddScoped<IStaffNotificationService, StaffNotificationService>();
        services.AddScoped<IService<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>, StaffNotificationService>();
        services.AddScoped<IAdditionalFeatures<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>, StaffNotificationService>();
        services.AddAutoMapper(typeof(StaffNotificationMapper));
        services.AddScoped<IAdditionalFeaturesRepository<StaffNotification>, AdditionalFeaturesRepository<StaffNotification>>();
    }
}
