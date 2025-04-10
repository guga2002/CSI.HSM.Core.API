using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Mapper;
using Core.Application.Services.Item.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Item;
using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Item;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Item.DI;

public static class ItemCategoryToStaffCategoryDI
{
    public static void InjectItemCategoryToStaffCategory(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<ItemCategoryToStaffCategory>, ItemCategoryToStaffCategoryRepository>();
        services.AddScoped<IItemCategoryToStaffCategoryRepository, ItemCategoryToStaffCategoryRepository>();
        services.AddScoped<IItemCategoryToStaffCategoryService, ItemCategoryToStaffCategoryService>();
        services.AddScoped<IService<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>, ItemCategoryToStaffCategoryService>();
        services.AddScoped<IAdditionalFeatures<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>, ItemCategoryToStaffCategoryService>();
        services.AddScoped<IAdditionalFeaturesRepository<ItemCategoryToStaffCategory>, AdditionalFeaturesRepository<ItemCategoryToStaffCategory>>();
        services.AddAutoMapper(typeof(ItemCategoryToStaffCategoryMapper));
    }
}
