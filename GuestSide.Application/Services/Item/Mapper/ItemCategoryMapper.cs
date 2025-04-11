using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Domain.Core.Entities.Item;

namespace Core.Application.Services.Item.Mapper;

public class ItemCategoryMapper : Profile
{
    public ItemCategoryMapper()
    {
        CreateMap<ItemCategoryDto, ItemCategory>().ReverseMap();
        CreateMap<ItemCategory, ItemCategoryResponseDto>().ReverseMap();
    }
}
