﻿using Core.Application.DTOs.Request.Restaurant;
using Core.Application.DTOs.Response.Restaurant;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Restaurant;

namespace Core.Application.Interface.Restaurant;

public interface IRestaurantItemCategoryService:IService<RestaurantItemCategoryDto,RestaurantItemCategoryResponseDto,long,RestaurantItemCategory>,
    IAdditionalFeatures<RestaurantItemCategoryDto, RestaurantItemCategoryResponseDto, long, RestaurantItemCategory>
{
}
