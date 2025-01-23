using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Restaurant;
using GuestSide.API.CustomExtendControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Restaurant;

[Route("api/[controller]")]
[ApiController]
public class RestaurantItemCategoryController : CSIControllerBase<RestaurantItemCategoryDto, RestaurantItemCategoryResponseDto, long, RestaurantItemCategory>
{
    public RestaurantItemCategoryController(IService<RestaurantItemCategoryDto, RestaurantItemCategoryResponseDto, long, RestaurantItemCategory> serviceProvider, IAdditionalFeatures<RestaurantItemCategoryDto, RestaurantItemCategoryResponseDto, long, RestaurantItemCategory> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
