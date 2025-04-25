using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Domain.Core.Entities.Staff;

namespace Core.Application.Services.Staff.Incident.Mapper;

public class IncidentTypeMapper : Profile
{
    public IncidentTypeMapper()
    {
        CreateMap<IncidentTypeDto, IncidentType>().ReverseMap();
        CreateMap<IncidentTypeResponseDto, IncidentType>().ReverseMap();
    }
}
