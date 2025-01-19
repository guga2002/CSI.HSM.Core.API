using AutoMapper;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;

namespace Core.Application.Services.Item.Mapper;

public class ItemCategoryMapper:Profile
{
    public ItemCategoryMapper()
    {
        CreateMap<ItemCategoryDto,ItemCategory>().ReverseMap();
        CreateMap<ItemCategory,ItemCategoryResponseDto>().ReverseMap();
    }
}
