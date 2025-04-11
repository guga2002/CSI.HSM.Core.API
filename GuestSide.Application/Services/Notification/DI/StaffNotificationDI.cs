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
