using AutoMapper;
using Common.Data.Entities.Restaurant;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;

namespace Core.Application.Services.Restaurant.Mapper;

public class RestaurantMapper : Profile
{
    public RestaurantMapper()
    {
        CreateMap<RestaurantDto, Restaurants>().ReverseMap();
        CreateMap<Restaurants, RestaurantResponseDto>().ReverseMap();
    }
}
