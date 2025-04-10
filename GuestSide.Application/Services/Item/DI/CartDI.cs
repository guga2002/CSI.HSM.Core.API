using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Item.Mapper;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.Services.Item.Services;
using Core.Application.Interface.Item;
using Core.Infrastructure.Repositories.Item;
using Domain.Core.Interfaces.Item;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Entities.Item;

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
