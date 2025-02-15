using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item.Services;

public class ItemService : GenericService<ItemDto, ItemResponseDto, long, Items>, IItemService
{
    public ItemService(IMapper mapper,
        IGenericRepository<Items> repository,
        ILogger<GenericService<ItemDto, ItemResponseDto, long, Items>> logger,
        IAdditionalFeaturesRepository<Items> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
