using Microsoft.Extensions.DependencyInjection;
using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Mapper;
using Core.Application.Services.Item.Services;
using Common.Data.Entities.Item;
using Common.Data.Interfaces.Item;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Item;
using Common.Data.Repositories.AbstractRepository;

namespace Core.Application.Services.Item.DI;

public static class ItemDI
{
    public static void InjectItem(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Items>, ItemsRepository>();
        services.AddScoped<IItemsRepository, ItemsRepository>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IService<ItemDto, ItemResponseDto, long, Items>, ItemService>();
        services.AddScoped<IAdditionalFeatures<ItemDto, ItemResponseDto, long, Items>, ItemService>();
        services.AddAutoMapper(typeof(ItemMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Items>, AdditionalFeaturesRepository<Items>>();
    }
}
