using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Domain.Core.Entities.Item;

namespace Core.Application.Services.Item.Mapper;

public class ItemMapper : Profile
{
    public ItemMapper()
    {
        CreateMap<ItemDto, Items>().ReverseMap();
        CreateMap<Items, ItemResponseDto>().ReverseMap();
    }
}
