using AutoMapper;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.Restaurant;
using Core.Core.Entities.Restaurant;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Restaurant.Services;

public class RestaurantCartService : GenericService<RestaurantCartDto, RestaurantCartResponseDto, long, RestaurantCart>, IRestaurantCartService
{
    public RestaurantCartService(IMapper mapper, IGenericRepository<RestaurantCart> repository, ILogger<GenericService<RestaurantCartDto, RestaurantCartResponseDto, long, RestaurantCart>> logger, IAdditionalFeaturesRepository<RestaurantCart> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
