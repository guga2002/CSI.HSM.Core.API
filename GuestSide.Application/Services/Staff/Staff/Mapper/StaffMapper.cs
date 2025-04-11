using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Domain.Core.Entities.Staff;

namespace Core.Application.Services.Staff.Staff.Mapper;

public class StaffMapper : Profile
{
    public StaffMapper()
    {
        CreateMap<StaffDto, Staffs>().ReverseMap();
        CreateMap<Staffs, StaffResponseDto>().ReverseMap();
    }
}
