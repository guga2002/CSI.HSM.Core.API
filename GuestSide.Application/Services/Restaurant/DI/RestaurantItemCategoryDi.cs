﻿using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Restaurant;
using Core.Application.Services.Restaurant.Mapper;
using Core.Application.Services.Restaurant.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Restaurant;
using Domain.Core.Entities.Restaurant;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Restaurant;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Restaurant.DI;

public static class RestaurantItemCategoryDi
{

    public static void AddRestaurantItemCategory(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<RestaurantItemCategory>, RestaurantItemCategoryRepository>();
        services.AddScoped<IRestaurantItemCategoryRepository, RestaurantItemCategoryRepository>();
        services.AddScoped<IRestaurantItemCategoryService, RestaurantItemCategoryService>();
        services.AddScoped<IService<RestaurantItemCategoryDto, RestaurantItemCategoryResponseDto, long, RestaurantItemCategory>, RestaurantItemCategoryService>();
        services.AddScoped<IAdditionalFeatures<RestaurantItemCategoryDto, RestaurantItemCategoryResponseDto, long, RestaurantItemCategory>, RestaurantItemCategoryService>();
        services.AddAutoMapper(typeof(RestaurantItemCategoryMapper));
        services.AddScoped<IAdditionalFeaturesRepository<RestaurantItemCategory>, AdditionalFeaturesRepository<RestaurantItemCategory>>();
    }
}
