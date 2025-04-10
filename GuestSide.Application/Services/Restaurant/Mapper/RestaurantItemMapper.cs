using AutoMapper;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Domain.Core.Entities.Restaurant;

namespace Core.Application.Services.Restaurant.Mapper;

public class RestaurantItemMapper:Profile
{
    public RestaurantItemMapper()
    {
        CreateMap<RestaunrantItemDto, RestaurantItem>().ReverseMap();
        CreateMap<RestaurantItem, RestaurantItemResponseDto>().ReverseMap();
    }
}
