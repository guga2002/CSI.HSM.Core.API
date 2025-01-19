using AutoMapper;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Core.Entities.Restaurant;

namespace Core.Application.Services.Restaurant.Mapper;

public class RestaurantMapper:Profile
{
    public RestaurantMapper()
    {
        CreateMap<RestaurantDto, Restaurants>().ReverseMap();
        CreateMap<Restaurants, RestaurantResponseDto>().ReverseMap();
    }
}
