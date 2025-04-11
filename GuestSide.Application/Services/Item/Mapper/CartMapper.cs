using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Domain.Core.Entities.Item;

namespace Core.Application.Services.Item.Mapper;

public class CartMapper:Profile
{
    public CartMapper()
    {
        CreateMap<CartDto, Cart>().ReverseMap();
        CreateMap<Cart, CartResponseDto>();
    }
}
