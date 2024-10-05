using GuestSide.Application.DTOs.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Application.Interface;
using GuestSide.Application.Services.Notification.Service;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Infrastructure.Repositories.Notification;
using Microsoft.Extensions.DependencyInjection;

namespace GuestSide.Application.Services.Notification.DI
{
    public static class NotificationDI
    {
        public static void InjectNotification(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Notifications>, NotificationRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IService<NotificationDto, long, Notifications>, NotificationService>();
        }
    }
}
