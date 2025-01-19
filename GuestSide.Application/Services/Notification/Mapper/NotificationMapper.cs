using AutoMapper;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Core.Entities.Notification;

namespace Core.Application.Services.Notification.Mapper;

public class NotificationMapper:Profile
{
    public NotificationMapper()
    {
        CreateMap<NotificationDto, Notifications>().ReverseMap();
        CreateMap<Notifications, NotificationResponseDto>().ReverseMap();
    }
}
