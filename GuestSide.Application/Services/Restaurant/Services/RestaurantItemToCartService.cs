using AutoMapper;
using Common.Data.Entities.Restaurant;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.Restaurant;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Restaurant.Services;

public class RestaurantItemToCartService : GenericService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, RestaurantItemToCart>, IRestaurantItemToCartService
{
    public RestaurantItemToCartService(IMapper mapper, IGenericRepository<RestaurantItemToCart> repository, ILogger<GenericService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, RestaurantItemToCart>> logger, IAdditionalFeaturesRepository<RestaurantItemToCart> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
