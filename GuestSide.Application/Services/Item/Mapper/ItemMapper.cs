using AutoMapper;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;

namespace Core.Application.Services.Item.Mapper;

public class ItemMapper:Profile
{
    public ItemMapper()
    {
        CreateMap<ItemDto,Items>().ReverseMap();
        CreateMap<Items,ItemResponseDto>().ReverseMap();
    }
}
