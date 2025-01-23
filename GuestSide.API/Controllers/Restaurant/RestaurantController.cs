using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Restaurant;
using GuestSide.API.CustomExtendControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Restaurant;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : CSIControllerBase<RestaurantDto, RestaurantResponseDto, long, Core.Entities.Restaurant.Restaurants>
{
    public RestaurantController(IService<RestaurantDto, RestaurantResponseDto, long, Restaurants> serviceProvider, IAdditionalFeatures<RestaurantDto, RestaurantResponseDto, long, Restaurants> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
