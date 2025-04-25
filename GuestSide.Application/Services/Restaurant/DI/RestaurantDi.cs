using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Restaurant;
using Core.Application.Services.Restaurant.Mapper;
using Core.Application.Services.Restaurant.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Restaurant;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Restaurant;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Restaurant.DI;

public static class RestaurantDi
{

    public static void AddRestaurantServices(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Domain.Core.Entities.Restaurant.Restaurants>, RestaurantRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IService<RestaurantDto, RestaurantResponseDto, long, Domain.Core.Entities.Restaurant.Restaurants>, RestaurantService>();
        services.AddScoped<IAdditionalFeatures<RestaurantDto, RestaurantResponseDto, long, Domain.Core.Entities.Restaurant.Restaurants>, RestaurantService>();
        services.AddAutoMapper(typeof(RestaurantMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Domain.Core.Entities.Restaurant.Restaurants>, AdditionalFeaturesRepository<Domain.Core.Entities.Restaurant.Restaurants>>();
    }
}
