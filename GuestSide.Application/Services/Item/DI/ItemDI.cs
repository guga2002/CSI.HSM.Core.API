using GuestSide.Application.DTOs.Item;
using GuestSide.Application.Interface.Item;
using GuestSide.Application.Interface;
using GuestSide.Application.Services.Item.Services;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Infrastructure.Repositories.Item;
using Microsoft.Extensions.DependencyInjection;

namespace GuestSide.Application.Services.Item.DI
{
    public static class ItemDI
    {
        public static void InjectItem(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Items>, ItemRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IService<ItemDto, long, Items>, ItemService>();
        }
    }
}
