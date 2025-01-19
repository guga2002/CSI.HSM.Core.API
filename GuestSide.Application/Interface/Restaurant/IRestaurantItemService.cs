using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Restaurant;

public interface IRestaurantItemService:IService<RestaunrantItemDto, RestaurantItemResponseDto,long, Core.Entities.Restaurant.RestaunrantItem>,
    IAdditionalFeatures<RestaunrantItemDto, RestaurantItemResponseDto, long, Core.Entities.Restaurant.RestaunrantItem>
{
}
