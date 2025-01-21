using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Core.Application.Services.Item.Mapper;
using Core.Application.Services.Item.Services;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Item;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Item;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Item.DI;

public static  class OrderableItemDi
{
    public static void InjectOrderableItem(this IServiceCollection services)
    {

        services.AddScoped<IGenericRepository<OrderableItem>, OrderableItemRepository>();
        services.AddScoped<IOrderableItemRepository, OrderableItemRepository>();
        services.AddScoped<IOrderableItemService, OrderableItemService>();
        services.AddScoped<IService<OrderableItemDto, OrderableItemResponseDto, long, OrderableItem>, OrderableItemService>();
        services.AddScoped<IAdditionalFeatures<OrderableItemDto, OrderableItemResponseDto, long, OrderableItem>, OrderableItemService>();
        services.AddAutoMapper(typeof(OrdarableItemMapper));
        services.AddScoped<IAdditionalFeaturesRepository<OrderableItem>, AdditionalFeaturesRepository<OrderableItem>>();

    }

}
