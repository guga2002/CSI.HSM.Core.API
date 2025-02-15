using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Item.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.Services.Item.Services;
using Core.Application.Interface.Item;
using Core.Infrastructure.Repositories.Item;

namespace Core.Application.Services.Item.DI;

public static class ItemDI
{
    public static void InjectItem(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Items>, ItemRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IService<ItemDto, ItemResponseDto, long, Items>, ItemService>();
        services.AddScoped<IAdditionalFeatures<ItemDto, ItemResponseDto, long, Items>, ItemService>();
        services.AddAutoMapper(typeof(ItemMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Items>, AdditionalFeaturesRepository<Items>>();
    }
}
