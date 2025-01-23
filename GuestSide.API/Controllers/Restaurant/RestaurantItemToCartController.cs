using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Restaurant;
using GuestSide.API.CustomExtendControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Restaurant;

[Route("api/[controller]")]
[ApiController]
public class RestaurantItemToCartController : CSIControllerBase<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, Core.Entities.Restaurant.RestaurantItemToCart>
{
    public RestaurantItemToCartController(IService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, RestaurantItemToCart> serviceProvider, IAdditionalFeatures<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, RestaurantItemToCart> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
