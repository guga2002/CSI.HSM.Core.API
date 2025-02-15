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

public static class RestaurantDi
{

    public static void AddRestaurantServices(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Core.Entities.Restaurant.Restaurants>, RestaurantRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IService<RestaurantDto, RestaurantResponseDto, long, Core.Entities.Restaurant.Restaurants>, RestaurantService>();
        services.AddScoped<IAdditionalFeatures<RestaurantDto, RestaurantResponseDto, long, Core.Entities.Restaurant.Restaurants>, RestaurantService>();
        services.AddAutoMapper(typeof(RestaurantMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Core.Entities.Restaurant.Restaurants>, AdditionalFeaturesRepository<Core.Entities.Restaurant.Restaurants>>();
    }
}
