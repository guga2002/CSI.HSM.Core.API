using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Infrastructure.Repositories.Notification;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Application.Services.Notification.Service;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;

namespace GuestSide.Application.Services.Notification.DI
{
    public static class GuestNotificationDI
    {
        public static void InjectGuestNotification(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<GuestNotification>, GuestNotificationRepository>();
            services.AddScoped<IGuestNotificationRepository, GuestNotificationRepository>();
            services.AddScoped<IGuestNotificationService, GuestNotificationService>();
            services.AddScoped<IService<GuestNotificationDto,GuestNotificationResponseDto, long, GuestNotification>, GuestNotificationService>();
        }
    }
}
