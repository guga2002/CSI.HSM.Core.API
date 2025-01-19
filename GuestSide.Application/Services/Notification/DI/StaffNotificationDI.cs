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

namespace GuestSide.Application.Services.Notification.DI;

public static class StaffNotificationDI
{
    public static void InjectStaffNotification(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<StaffNotification>, StaffNotificationRepository>();
        services.AddScoped<IStaffNotificationRepository, StaffNotificationRepository>();
        services.AddScoped<IStaffNotificationService, StaffNotificationService>();
        services.AddScoped<IService<StafNotificationDto,StafNotificationResponseDto, long, StaffNotification>, StaffNotificationService>();
        services.AddScoped<IAdditionalFeatures<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>, StaffNotificationService>();
        services.AddAutoMapper(typeof(StaffNotificationMapper));
    }
}
