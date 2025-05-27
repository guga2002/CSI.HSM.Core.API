using AutoMapper;
using Common.Data.Entities.Restaurant;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.Restaurant;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Restaurant.Services;

public class RestaurantItemService : GenericService<RestaunrantItemDto, RestaurantItemResponseDto, long, RestaurantItem>, IRestaurantItemService
{
    public RestaurantItemService(IMapper mapper, IGenericRepository<RestaurantItem> repository, ILogger<GenericService<RestaunrantItemDto, RestaurantItemResponseDto, long, RestaurantItem>> logger, IAdditionalFeaturesRepository<RestaurantItem> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
