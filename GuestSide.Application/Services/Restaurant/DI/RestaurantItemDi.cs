using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Restaurant;
using Core.Application.Services.Restaurant.Mapper;
using Core.Application.Services.Restaurant.Services;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Restaurant;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Restaurant;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Restaurant.DI;

public static class RestaurantItemDi
{

    public static void AddRestaurantItem(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Core.Entities.Restaurant.RestaunrantItem>, RestaunrantItemRepository>();
        services.AddScoped<IRestaunrantItemRepository, RestaunrantItemRepository>();
        services.AddScoped<IRestaurantItemService, RestaurantItemService>();
        services.AddScoped<IService<RestaunrantItemDto, RestaurantItemResponseDto, long, Core.Entities.Restaurant.RestaunrantItem>, RestaurantItemService>();
        services.AddScoped<IAdditionalFeatures<RestaunrantItemDto, RestaurantItemResponseDto, long, Core.Entities.Restaurant.RestaunrantItem>, RestaurantItemService>();
        services.AddAutoMapper(typeof(RestaurantItemMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Core.Entities.Restaurant.RestaunrantItem>, AdditionalFeaturesRepository<Core.Entities.Restaurant.RestaunrantItem>>();
    }
}
