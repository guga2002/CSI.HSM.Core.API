using AutoMapper;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;

namespace Core.Application.Services.Staff.Category.Mapper;

public class StaffCategoryMapper:Profile
{
    public StaffCategoryMapper()
    {
        CreateMap<StaffCategoryDto, StaffCategory>().ReverseMap();
        CreateMap<StaffCategory, StaffCategoryResponseDto>().ReverseMap();
    }
}
