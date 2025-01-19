﻿using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Core.Entities.Item;
using GuestSide.Infrastructure.Repositories.Item;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Application.Services.Item.Services;
using GuestSide.Application.Interface.Item;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;

namespace GuestSide.Application.Services.Item.DI
{
    public static class ItemCategoryDI
    {
        public static void InjectItemCategory(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<ItemCategory>, ItemCategoryRepository>();
            services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
            services.AddScoped<IItemCategoryService, ItemCategoryService>();
            services.AddScoped<IService<ItemCategoryDto,ItemCategoryResponseDto, long, ItemCategory>, ItemCategoryService>();
        }
    }
}
