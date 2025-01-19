using AutoMapper;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;

namespace Core.Application.Services.Staff.Staff.Mapper;

public class StaffMapper:Profile
{
    public StaffMapper()
    {
        CreateMap<StaffDto, Staffs>().ReverseMap();
        CreateMap<Staffs, StaffResponseDto>().ReverseMap();
    }
}
