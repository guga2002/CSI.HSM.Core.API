using AutoMapper;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Domain.Core.Entities.Notification;

namespace Core.Application.Services.Notification.Mapper;

public class StaffNotificationMapper : Profile
{
    public StaffNotificationMapper()
    {
        CreateMap<StafNotificationDto, StaffNotification>().ReverseMap();
        CreateMap<StaffNotification, StafNotificationResponseDto>().ReverseMap();
    }
}
