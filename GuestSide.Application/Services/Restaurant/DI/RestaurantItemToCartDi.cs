using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Restaurant;
using Core.Application.Services.Restaurant.Mapper;
using Core.Application.Services.Restaurant.Services;
using Core.Core.Entities.Restaurant;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Restaurant;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Restaurant;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Restaurant.DI;

public static class RestaurantItemToCartDi
{

    public static void AddRestaurantItemToCart(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Core.Entities.Restaurant.RestaurantItemToCart>, RestaurantItemToCartRepository>();
        services.AddScoped<IRestaurantItemToCartRepository, RestaurantItemToCartRepository>();
        services.AddScoped<IRestaurantItemToCartService, RestaurantItemToCartService>();
        services.AddScoped<IService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, Core.Entities.Restaurant.RestaurantItemToCart>, RestaurantItemToCartService>();
        services.AddScoped<IAdditionalFeatures<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, Core.Entities.Restaurant.RestaurantItemToCart>, RestaurantItemToCartService>();
        services.AddAutoMapper(typeof(RestaurantItemToCartMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Core.Entities.Restaurant.RestaurantItemToCart>, AdditionalFeaturesRepository<Core.Entities.Restaurant.RestaurantItemToCart>>();
    }
}
