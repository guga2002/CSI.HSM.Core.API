using Common.Data.Entities.Restaurant;
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
