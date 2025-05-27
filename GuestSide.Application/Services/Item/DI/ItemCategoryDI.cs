using Microsoft.Extensions.DependencyInjection;
using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Services;
using Core.Application.Services.Item.Mapper;
using Common.Data.Entities.Item;
using Common.Data.Interfaces.Item;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Item;
using Common.Data.Repositories.AbstractRepository;

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
