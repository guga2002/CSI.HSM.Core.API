using AutoMapper;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Core.Entities.Notification;

namespace Core.Application.Services.Notification.Mapper;

public class StaffNotificationMapper:Profile
{
    public StaffNotificationMapper()
    {
        CreateMap<StafNotificationDto, StaffNotification>().ReverseMap();
        CreateMap<StaffNotification, StafNotificationResponseDto>().ReverseMap();
    }
}
