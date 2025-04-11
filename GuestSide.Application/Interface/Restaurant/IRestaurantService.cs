using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Restaurant;

namespace Core.Application.Interface.Restaurant;

public interface IRestaurantService:IService<RestaurantDto, RestaurantResponseDto, long, Restaurants>,
    IAdditionalFeatures<RestaurantDto, RestaurantResponseDto, long, Restaurants>
{
}
