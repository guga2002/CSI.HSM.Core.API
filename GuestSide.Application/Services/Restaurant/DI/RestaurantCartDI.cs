using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Restaurant;
using Core.Application.Services.Payment.PaymentOption.Mapper;
using Core.Application.Services.Restaurant.Mapper;
using Core.Application.Services.Restaurant.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Restaurant;
using Domain.Core.Entities.Restaurant;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Restaurant;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Restaurant.DI;

public static class RestaurantCartDI
{

    public static void AddRestaurantCartServices(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<RestaurantCart>, RestaurantCartRepository>();
        services.AddScoped<IRestaurantCartRepository, RestaurantCartRepository>();
        services.AddScoped<IRestaurantCartService, RestaurantCartService>();
        services.AddScoped<IService<RestaurantCartDto, RestaurantCartResponseDto, long, RestaurantCart>, RestaurantCartService>();
        services.AddScoped<IAdditionalFeatures<RestaurantCartDto, RestaurantCartResponseDto, long, RestaurantCart>,RestaurantCartService> ();
        services.AddAutoMapper(typeof(RestaurantCartMapper));
        services.AddScoped<IAdditionalFeaturesRepository<RestaurantCart>, AdditionalFeaturesRepository<RestaurantCart>>();
    }
}
