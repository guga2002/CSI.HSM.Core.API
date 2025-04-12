using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Restaurant;

public interface IRestaurantService : IService<RestaurantDto, RestaurantResponseDto, long, Domain.Core.Entities.Restaurant.Restaurants>,
    IAdditionalFeatures<RestaurantDto, RestaurantResponseDto, long, Domain.Core.Entities.Restaurant.Restaurants>
{
}
