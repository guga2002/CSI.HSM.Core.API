using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item.Services;

public class OrderableItemService : GenericService<OrderableItemDto, OrderableItemResponseDto, long, OrderableItem>, IOrderableItemService
{
    public OrderableItemService(IMapper mapper, IGenericRepository<OrderableItem> repository, ILogger<GenericService<OrderableItemDto, OrderableItemResponseDto, long, OrderableItem>> logger, IAdditionalFeaturesRepository<OrderableItem> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
