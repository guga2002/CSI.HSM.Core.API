using AutoMapper;
using Common.Data.Entities.Restaurant;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.Restaurant;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Restaurant.Services;

public class RestaurantItemCategoryService : GenericService<RestaurantItemCategoryDto, RestaurantItemCategoryResponseDto, long, RestaurantItemCategory>, IRestaurantItemCategoryService
{
    public RestaurantItemCategoryService(IMapper mapper, IGenericRepository<RestaurantItemCategory> repository, ILogger<GenericService<RestaurantItemCategoryDto, RestaurantItemCategoryResponseDto, long, RestaurantItemCategory>> logger, IAdditionalFeaturesRepository<RestaurantItemCategory> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
