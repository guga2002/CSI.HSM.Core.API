using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Restaurant;

namespace Core.Application.Interface.Restaurant;

public interface IRestaurantItemService:IService<RestaunrantItemDto, RestaurantItemResponseDto,long, RestaurantItem>,
    IAdditionalFeatures<RestaunrantItemDto, RestaurantItemResponseDto, long, RestaurantItem>
{
}
