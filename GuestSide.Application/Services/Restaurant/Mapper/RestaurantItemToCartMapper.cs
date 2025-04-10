using AutoMapper;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Domain.Core.Entities.Restaurant;

namespace Core.Application.Services.Restaurant.Mapper;

public class RestaurantItemToCartMapper:Profile
{
    public RestaurantItemToCartMapper()
    {
        CreateMap<RestaurantItemToCartDto, RestaurantItemToCart>().ReverseMap();
        CreateMap<RestaurantItemToCart, RestaurantItemToCartResponseDto>().ReverseMap();
    }
}
