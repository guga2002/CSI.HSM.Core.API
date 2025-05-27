using AutoMapper;
using Common.Data.Entities.Restaurant;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;

namespace Core.Application.Services.Restaurant.Mapper;

public class RestaurantCartMapper : Profile
{
    public RestaurantCartMapper()
    {
        CreateMap<RestaurantCartDto, RestaurantCart>().ReverseMap();
        CreateMap<RestaurantCart, RestaurantCartResponseDto>().ReverseMap();
    }
}
