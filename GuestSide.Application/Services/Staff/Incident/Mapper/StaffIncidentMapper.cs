using AutoMapper;
using Common.Data.Entities.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;

namespace Core.Application.Services.Staff.Incident.Mapper;

public class StaffIncidentMapper : Profile
{

    public StaffIncidentMapper()
    {
        CreateMap<StaffIncident, StaffIncidentResponseDto>().ReverseMap();
        CreateMap<StaffIncident, StaffIncidentDto>().ReverseMap();
    }
}
