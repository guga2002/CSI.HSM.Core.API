using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Restaurant;
using GuestSide.API.CustomExtendControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Restaurant;

[Route("api/[controller]")]
[ApiController]
public class RestaurantItemController : CSIControllerBase<RestaunrantItemDto, RestaurantItemResponseDto, long, Core.Entities.Restaurant.RestaunrantItem>
{
    public RestaurantItemController(IService<RestaunrantItemDto, RestaurantItemResponseDto, long, RestaunrantItem> serviceProvider, IAdditionalFeatures<RestaunrantItemDto, RestaurantItemResponseDto, long, RestaunrantItem> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
