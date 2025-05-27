using AutoMapper;
using Common.Data.Entities.LogEntities;
using Core.Application.DTOs.Request.LogModel;
using Core.Application.DTOs.Response.LogModel;

namespace Core.Application.Services.LogService.Mapper;

public class LogMapper : Profile
{
    public LogMapper()
    {
        CreateMap<LogDto, Logs>().ReverseMap();
        CreateMap<Logs, LogResponseDto>().ReverseMap();
    }
}
