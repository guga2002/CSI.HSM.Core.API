﻿using Common.Data.Entities.Restaurant;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Restaurant;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Restaurant;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Restaurant;
using Core.Application.Services.Restaurant.Mapper;
using Core.Application.Services.Restaurant.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Restaurant.DI;

public static class RestaurantItemDi
{

    public static void AddRestaurantItem(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<RestaurantItem>, RestaunrantItemRepository>();
        services.AddScoped<IRestaunrantItemRepository, RestaunrantItemRepository>();
        services.AddScoped<IRestaurantItemService, RestaurantItemService>();
        services.AddScoped<IService<RestaunrantItemDto, RestaurantItemResponseDto, long, RestaurantItem>, RestaurantItemService>();
        services.AddScoped<IAdditionalFeatures<RestaunrantItemDto, RestaurantItemResponseDto, long, RestaurantItem>, RestaurantItemService>();
        services.AddAutoMapper(typeof(RestaurantItemMapper));
        services.AddScoped<IAdditionalFeaturesRepository<RestaurantItem>, AdditionalFeaturesRepository<RestaurantItem>>();
    }
}
