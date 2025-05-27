using AutoMapper;
using Common.Data.Entities.Restaurant;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;

namespace Core.Application.Services.Restaurant.Mapper;

public class RestaurantItemToCartMapper : Profile
{
    public RestaurantItemToCartMapper()
    {
        CreateMap<RestaurantItemToCartDto, RestaurantItemToCart>().ReverseMap();
        CreateMap<RestaurantItemToCart, RestaurantItemToCartResponseDto>().ReverseMap();
    }
}
