﻿using AutoMapper;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;

namespace Core.Application.Services.Item.Mapper;

public class CartMapper:Profile
{
    public CartMapper()
    {
        CreateMap<CartDto, Cart>().ReverseMap();
        CreateMap<Cart, CartResponseDto>().ReverseMap();
    }
}
