using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Domain.Core.Entities.Item;

namespace Core.Application.Services.Item.Mapper;

public class ItemCategoryToStaffCategoryMapper : Profile
{
    public ItemCategoryToStaffCategoryMapper()
    {
        CreateMap<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategory>().ReverseMap();
        CreateMap<ItemCategoryToStaffCategory, ItemCategoryToStaffCategoryResponseDto>().ReverseMap();
    }
}
