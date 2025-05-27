using AutoMapper;
using Common.Data.Entities.Notification;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;

namespace Core.Application.Services.Notification.Mapper;

public class GuestNotificationMapper : Profile
{
    public GuestNotificationMapper()
    {
        CreateMap<GuestNotificationDto, GuestNotification>().ReverseMap();
        CreateMap<GuestNotification, GuestNotificationResponseDto>().ReverseMap();
    }
}
