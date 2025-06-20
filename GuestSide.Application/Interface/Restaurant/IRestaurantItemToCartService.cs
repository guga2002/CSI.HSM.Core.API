﻿using Common.Data.Entities.Restaurant;
using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Restaurant;

public interface IRestaurantItemToCartService : IService<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, RestaurantItemToCart>,
    IAdditionalFeatures<RestaurantItemToCartDto, RestaurantItemToCartResponseDto, long, RestaurantItemToCart>
{
}
