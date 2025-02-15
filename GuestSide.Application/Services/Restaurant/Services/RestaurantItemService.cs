using AutoMapper;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.Restaurant;
using Core.Core.Entities.Restaurant;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Restaurant.Services;

public class RestaurantItemService : GenericService<RestaunrantItemDto, RestaurantItemResponseDto, long, Core.Entities.Restaurant.RestaunrantItem>, IRestaurantItemService
{
    public RestaurantItemService(IMapper mapper, IGenericRepository<RestaunrantItem> repository, ILogger<GenericService<RestaunrantItemDto, RestaurantItemResponseDto, long, RestaunrantItem>> logger, IAdditionalFeaturesRepository<RestaunrantItem> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
