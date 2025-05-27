using AutoMapper;
using Common.Data.Entities.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;

namespace Core.Application.Services.Item.Mapper;

public class ItemCategoryMapper : Profile
{
    public ItemCategoryMapper()
    {
        CreateMap<ItemCategoryDto, ItemCategory>().ReverseMap();
        CreateMap<ItemCategory, ItemCategoryResponseDto>().ReverseMap();
    }
}
