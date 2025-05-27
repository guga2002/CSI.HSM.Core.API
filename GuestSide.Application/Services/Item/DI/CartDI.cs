using Microsoft.Extensions.DependencyInjection;
using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Services;
using Core.Application.Services.Item.Mapper;
using Common.Data.Entities.Item;
using Common.Data.Interfaces.Item;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Item;
using Common.Data.Repositories.AbstractRepository;

namespace Core.Application.Services.Item.DI;

public static class CartDI
{
    public static void InjectCart(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Cart>, CartRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IService<CartDto, CartResponseDto, long, Cart>, CartService>();
        services.AddScoped<IAdditionalFeatures<CartDto, CartResponseDto, long, Cart>, CartService>();
        services.AddScoped<IAdditionalFeaturesRepository<Cart>, AdditionalFeaturesRepository<Cart>>();
        services.AddAutoMapper(typeof(CartMapper));
    }
}
