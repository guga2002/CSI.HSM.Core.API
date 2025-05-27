using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;

namespace Core.Application.Services.Staff.StaffSupport.Mapper;

public class StaffSupportMapper : Profile
{

    public StaffSupportMapper()
    {
        CreateMap<Common.Data.Entities.Staff.StaffSupport, StaffSupportDto>().ReverseMap();
        CreateMap<Common.Data.Entities.Staff.StaffSupport, StaffSupportResponseDto>().ReverseMap();
    }
}
