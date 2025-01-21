using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Core.Entities.Restaurant;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Restaurant;

[Route("api/[controller]")]
[ApiController]
public class RestaurantCartController : CSIControllerBase<RestaurantCartDto, RestaurantCartResponseDto, long, RestaurantCart>
{
    public RestaurantCartController(IService<RestaurantCartDto, RestaurantCartResponseDto, long, RestaurantCart> serviceProvider, IAdditionalFeatures<RestaurantCartDto, RestaurantCartResponseDto, long, RestaurantCart> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
