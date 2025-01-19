using AutoMapper;
using GuestSide.Application.DTOs.Request.LogModel;
using GuestSide.Application.DTOs.Response.LogModel;
using GuestSide.Core.Entities.LogEntities;

namespace Core.Application.Services.LogService.Mapper;

public class LogMapper:Profile
{
    public LogMapper()
    {
        CreateMap<LogDto,Logs>().ReverseMap();
        CreateMap<Logs,LogResponseDto>().ReverseMap();
    }
}
