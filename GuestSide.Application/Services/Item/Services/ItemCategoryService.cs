using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item.Services;

public class ItemCategoryService : GenericService<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>, IItemCategoryService
{
    public ItemCategoryService(IMapper mapper,
        IGenericRepository<ItemCategory> repository,
        ILogger<GenericService<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>> logger,
        IAdditionalFeaturesRepository<ItemCategory> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
