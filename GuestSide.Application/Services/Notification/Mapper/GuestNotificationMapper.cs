using AutoMapper;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Domain.Core.Entities.Notification;

namespace Core.Application.Services.Notification.Mapper;

public class GuestNotificationMapper : Profile
{
    public GuestNotificationMapper()
    {
        CreateMap<GuestNotificationDto, GuestNotification>().ReverseMap();
        CreateMap<GuestNotification, GuestNotificationResponseDto>().ReverseMap();
    }
}
