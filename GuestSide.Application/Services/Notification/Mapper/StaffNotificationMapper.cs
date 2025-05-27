using AutoMapper;
using Common.Data.Entities.Notification;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;

namespace Core.Application.Services.Notification.Mapper;

public class StaffNotificationMapper : Profile
{
    public StaffNotificationMapper()
    {
        CreateMap<StafNotificationDto, StaffNotification>().ReverseMap();
        CreateMap<StaffNotification, StafNotificationResponseDto>().ReverseMap();
    }
}
