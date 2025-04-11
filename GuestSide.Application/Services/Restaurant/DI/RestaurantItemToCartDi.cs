using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Restaurant;
using Core.Application.Services.Restaurant.Mapper;
using Core.Application.Services.Restaurant.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Restaurant;
using Domain.Core.Entities.Restaurant;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Restaurant;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Restaurant.DI;

public static class RestaurantItemToCartDi
{

    public static void AddRestaurantItemToCart(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<RestaurantItemToCart>, RestaurantItemToCartRepository>();
        services.AddScoped<IRestaurantItemToCartRepository, RestaurantItemToCartRepository>();
        services.AddScoped<IRestaurantItemToCartService, RestaurantItemToCartService>();
        services.AddScoped<IService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, RestaurantItemToCart>, RestaurantItemToCartService>();
        services.AddScoped<IAdditionalFeatures<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, RestaurantItemToCart>, RestaurantItemToCartService>();
        services.AddAutoMapper(typeof(RestaurantItemToCartMapper));
        services.AddScoped<IAdditionalFeaturesRepository<RestaurantItemToCart>, AdditionalFeaturesRepository<RestaurantItemToCart>>();
    }
}
