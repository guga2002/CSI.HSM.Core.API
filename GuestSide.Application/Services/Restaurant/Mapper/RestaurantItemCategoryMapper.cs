using AutoMapper;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Domain.Core.Entities.Restaurant;

namespace Core.Application.Services.Restaurant.Mapper;

public class RestaurantItemCategoryMapper:Profile
{
    public RestaurantItemCategoryMapper()
    {
        CreateMap<RestaurantItemCategoryDto, RestaurantItemCategory>().ReverseMap();
        CreateMap<RestaurantItemCategory, RestaurantItemCategoryResponseDto>().ReverseMap();
    }
}

