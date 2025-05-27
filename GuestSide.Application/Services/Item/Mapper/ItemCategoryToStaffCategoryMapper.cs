using AutoMapper;
using Common.Data.Entities.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;

namespace Core.Application.Services.Item.Mapper;

public class ItemCategoryToStaffCategoryMapper : Profile
{
    public ItemCategoryToStaffCategoryMapper()
    {
        CreateMap<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategory>().ReverseMap();
        CreateMap<ItemCategoryToStaffCategory, ItemCategoryToStaffCategoryResponseDto>().ReverseMap();
    }
}
