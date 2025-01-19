using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Core.Entities.Item;
using GuestSide.Infrastructure.Repositories.Item;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Application.Interface.Item;
using GuestSide.Application.Services.Item.Services;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;

namespace GuestSide.Application.Services.Item.DI
{
    public static class CartDI
    {
        public static void InjectCart(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Cart>, CartRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IService<CartDto,CartResponseDto, long, Cart>, CartService>();
        }
    }
}
