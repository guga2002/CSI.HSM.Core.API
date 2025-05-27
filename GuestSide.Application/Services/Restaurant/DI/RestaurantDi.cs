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

public static class RestaurantDi
{

    public static void AddRestaurantServices(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Restaurants>, RestaurantRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IService<RestaurantDto, RestaurantResponseDto, long, Restaurants>, RestaurantService>();
        services.AddScoped<IAdditionalFeatures<RestaurantDto, RestaurantResponseDto, long, Restaurants>, RestaurantService>();
        services.AddAutoMapper(typeof(RestaurantMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Restaurants>, AdditionalFeaturesRepository<Restaurants>>();
    }
}
