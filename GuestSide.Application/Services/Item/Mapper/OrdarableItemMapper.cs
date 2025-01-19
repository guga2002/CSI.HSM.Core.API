using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;

namespace Core.Application.Services.Item.Mapper;

public class OrdarableItemMapper:Profile
{
    public OrdarableItemMapper()
    {
        CreateMap<OrderableItemDto, OrderableItem>().ReverseMap();
        CreateMap<OrderableItem,OrderableItemResponseDto>().ReverseMap();
    }
}
