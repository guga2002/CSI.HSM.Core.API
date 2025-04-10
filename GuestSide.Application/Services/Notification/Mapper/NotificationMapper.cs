using AutoMapper;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Domain.Core.Entities.Notification;

namespace Core.Application.Services.Notification.Mapper;

public class NotificationMapper:Profile
{
    public NotificationMapper()
    {
        CreateMap<NotificationDto, Notifications>().ReverseMap();
        CreateMap<Notifications, NotificationResponseDto>().ReverseMap();
    }
}
