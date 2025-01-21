using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Restaurant;

public interface IRestaurantItemToCartService:IService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto,long, Core.Entities.Restaurant.RestaurantItemToCart>,
    IAdditionalFeatures<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, Core.Entities.Restaurant.RestaurantItemToCart>
{
}
