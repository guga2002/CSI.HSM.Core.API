using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Notification.Mapper;
using Core.Core.Entities.Payment;
using Core.Infrastructure.Repositories.Restaurant.Payment;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Application.Services.Notification.Service;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Infrastructure.Repositories.Notification;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.Payment.PaymentOption.DI;

public static class PaymentOptionDi
{
    public static void InjectPaymentOption(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<PaymentOption>, PaymentOptionRepository>();
        services.AddScoped<IGuestNotificationRepository, GuestNotificationRepository>();
        services.AddScoped<IGuestNotificationService, GuestNotificationService>();
        services.AddScoped<IService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>, GuestNotificationService>();
        services.AddScoped<IAdditionalFeatures<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>, GuestNotificationService>();
        services.AddAutoMapper(typeof(GuestNotificationMapper));
    }
}
