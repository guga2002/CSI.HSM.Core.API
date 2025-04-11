using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Domain.Core.Entities.Staff;

namespace Core.Application.Services.Staff.Incident.Mapper;

public class IncidentTypeToStaffCategoryMapper:Profile
{
    public IncidentTypeToStaffCategoryMapper()
    {
        CreateMap<IncidentTypeToStaffCategoryDto, IncidentTypeToStaffCategory>().ReverseMap();
        CreateMap<IncidentTypeToStaffCategory, IncidentTypeToStaffCategoryResponseDto>().ReverseMap();
    }
}
