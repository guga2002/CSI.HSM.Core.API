using AutoMapper;
using Common.Data.Entities.Restaurant;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;

namespace Core.Application.Services.Restaurant.Mapper;

public class RestaurantItemMapper : Profile
{
    public RestaurantItemMapper()
    {
        CreateMap<RestaunrantItemDto, RestaurantItem>().ReverseMap();
        CreateMap<RestaurantItem, RestaurantItemResponseDto>().ReverseMap();
    }
}
