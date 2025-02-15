﻿using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Item.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.Services.Item.Services;
using Core.Application.Interface.Item;
using Core.Infrastructure.Repositories.Item;

namespace Core.Application.Services.Item.DI;

public static class ItemCategoryDI
{
    public static void InjectItemCategory(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<ItemCategory>, ItemCategoryRepository>();
        services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
        services.AddScoped<IItemCategoryService, ItemCategoryService>();
        services.AddScoped<IService<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>, ItemCategoryService>();
        services.AddScoped<IAdditionalFeatures<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>, ItemCategoryService>();
        services.AddAutoMapper(typeof(ItemCategoryMapper));
        services.AddScoped<IAdditionalFeaturesRepository<ItemCategory>, AdditionalFeaturesRepository<ItemCategory>>();
    }
}
