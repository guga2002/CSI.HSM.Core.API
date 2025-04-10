using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Domain.Core.Entities.Staff;

namespace Core.Application.Services.Staff.Category.Mapper;

public class StaffCategoryMapper:Profile
{
    public StaffCategoryMapper()
    {
        CreateMap<StaffCategoryDto, StaffCategory>().ReverseMap();
        CreateMap<StaffCategory, StaffCategoryResponseDto>().ReverseMap();
    }
}
