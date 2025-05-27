using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;

namespace Core.Application.Services.Staff.StaffSupportResponse.Mapper;

public class StaffSupportResponseMapper : Profile
{
    public StaffSupportResponseMapper()
    {
        CreateMap<Common.Data.Entities.Staff.StaffSupportResponse, StaffSupportResponseResponseDto>().ReverseMap();
        CreateMap<Common.Data.Entities.Staff.StaffSupportResponse, StaffSupportResponseRequestDto>().ReverseMap();
    }
}
