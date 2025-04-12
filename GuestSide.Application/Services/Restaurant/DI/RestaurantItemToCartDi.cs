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
        services.AddScoped<IGenericRepository<Domain.Core.Entities.Restaurant.RestaurantItemToCart>, RestaurantItemToCartRepository>();
        services.AddScoped<IRestaurantItemToCartRepository, RestaurantItemToCartRepository>();
        services.AddScoped<IRestaurantItemToCartService, RestaurantItemToCartService>();
        services.AddScoped<IService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, Domain.Core.Entities.Restaurant.RestaurantItemToCart>, RestaurantItemToCartService>();
        services.AddScoped<IAdditionalFeatures<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, Domain.Core.Entities.Restaurant.RestaurantItemToCart>, RestaurantItemToCartService>();
        services.AddAutoMapper(typeof(RestaurantItemToCartMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Domain.Core.Entities.Restaurant.RestaurantItemToCart>, AdditionalFeaturesRepository<Domain.Core.Entities.Restaurant.RestaurantItemToCart>>();
    }
}
