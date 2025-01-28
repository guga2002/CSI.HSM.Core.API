using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Mapper;
using Core.Application.Services.Item.Services;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Item;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Item.DI;

public static class ItemCategoryToStaffCategoryDI
{
    public static void InjectCart(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<ItemCategoryToStaffCategory>, ItemCategoryToStaffCategoryRepository>();
        services.AddScoped<IItemCategoryToStaffCategory, ItemCategoryToStaffCategoryRepository>();
        services.AddScoped<IItemCategoryToStaffCategoryService, ItemCategoryToStaffCategoryService>();
        services.AddScoped<IService<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>, ItemCategoryToStaffCategoryService>();
        services.AddScoped<IAdditionalFeatures<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>, ItemCategoryToStaffCategoryService>();
        services.AddScoped<IAdditionalFeaturesRepository<ItemCategoryToStaffCategory>, AdditionalFeaturesRepository<ItemCategoryToStaffCategory>>();
        services.AddAutoMapper(typeof(ItemCategoryToStaffCategoryMapper));
    }
}
