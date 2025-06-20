﻿using Common.Data.Entities.Restaurant;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Restaurant;

public interface IRestaurantCartService : IService<RestaurantCartDto, RestaurantCartResponseDto, long, RestaurantCart>,
    IAdditionalFeatures<RestaurantCartDto, RestaurantCartResponseDto, long, RestaurantCart>
{
}
