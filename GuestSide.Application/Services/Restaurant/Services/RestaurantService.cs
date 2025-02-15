using AutoMapper;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.Restaurant;
using Core.Core.Entities.Restaurant;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Restaurant.Services;

public class RestaurantService : GenericService<RestaurantDto, RestaurantResponseDto, long, Core.Entities.Restaurant.Restaurants>, IRestaurantService
{
    public RestaurantService(IMapper mapper, IGenericRepository<Restaurants> repository, ILogger<GenericService<RestaurantDto, RestaurantResponseDto, long, Restaurants>> logger, IAdditionalFeaturesRepository<Restaurants> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
