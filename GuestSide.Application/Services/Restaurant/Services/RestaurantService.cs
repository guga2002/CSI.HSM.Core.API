using AutoMapper;
using Common.Data.Entities.Restaurant;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.Restaurant;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Restaurant.Services;

public class RestaurantService : GenericService<RestaurantDto, RestaurantResponseDto, long, Restaurants>, IRestaurantService
{
    public RestaurantService(IMapper mapper, IGenericRepository<Restaurants> repository, ILogger<GenericService<RestaurantDto, RestaurantResponseDto, long, Restaurants>> logger, IAdditionalFeaturesRepository<Restaurants> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
