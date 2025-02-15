using AutoMapper;
using Core.Application.DTOs.Request.LogModel;
using Core.Application.DTOs.Response.LogModel;
using Core.Core.Entities.LogEntities;

namespace Core.Application.Services.LogService.Mapper;

public class LogMapper:Profile
{
    public LogMapper()
    {
        CreateMap<LogDto,Logs>().ReverseMap();
        CreateMap<Logs,LogResponseDto>().ReverseMap();
    }
}
