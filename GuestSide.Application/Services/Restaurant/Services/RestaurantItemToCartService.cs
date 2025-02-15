using AutoMapper;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.Restaurant;
using Core.Core.Entities.Restaurant;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Restaurant.Services;

public class RestaurantItemToCartService : GenericService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, Core.Entities.Restaurant.RestaurantItemToCart>, IRestaurantItemToCartService
{
    public RestaurantItemToCartService(IMapper mapper, IGenericRepository<RestaurantItemToCart> repository, ILogger<GenericService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, RestaurantItemToCart>> logger, IAdditionalFeaturesRepository<RestaurantItemToCart> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
