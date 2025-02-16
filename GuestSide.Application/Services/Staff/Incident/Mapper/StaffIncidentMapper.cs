using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Core.Entities.Staff;

namespace Core.Application.Services.Staff.Incident.Mapper
{
    public class StaffIncidentMapper:Profile
    {

        public StaffIncidentMapper()
        {
            CreateMap<StaffIncident, StaffIncidentResponseDto>().ReverseMap();
            CreateMap<StaffIncident, StaffIncidentDto>().ReverseMap();
        }
    }
}
