using AutoMapper;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Core.Entities.Notification;

namespace Core.Application.Services.Notification.Mapper;

public class GuestNotificationMapper :Profile
{
    public GuestNotificationMapper()
    {
        CreateMap<GuestNotificationDto,GuestNotification>().ReverseMap();
        CreateMap<GuestNotification,GuestNotificationResponseDto>().ReverseMap();
    }
}
