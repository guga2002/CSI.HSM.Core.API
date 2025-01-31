using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.CustomExceptions;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Application.Interface.Item;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Item;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Item.Services;

public class CartService : GenericService<CartDto, CartResponseDto, long, Cart>, ICartService
{

    private readonly IMapper _map;
    ICartRepository _cartRepository;
    public CartService(IMapper mapper, 
        IGenericRepository<Cart> repository, 
        ILogger<GenericService<CartDto, CartResponseDto, long, Cart>> logger,
        IAdditionalFeaturesRepository<Cart> additioalFeatures,
        ICartRepository cartrep) 
        : base(mapper, repository, logger, additioalFeatures)
    {
        _map= mapper;
        _cartRepository=cartrep;
    }

    public async Task<CartResponseDto?> CartSymmary(long cartId)
    {
       var res=await _cartRepository.CartSymmary(cartId);
        if(res != null)
        {
            return _map.Map<CartResponseDto>(res);
        }
        throw new NotFoundException("Data not found");
    }

    public async Task<bool> ClearCart(long cartId)
    {
       return await _cartRepository.ClearCart(cartId);
    }

    public async Task<CartResponseDto> RemoveItemFromCart(long cartId, long itemId)//todo:add validation
    {
        var res = await _cartRepository.RemoveItemFromCart(cartId, itemId);
        if (res is not null)
        {
            return _map.Map<CartResponseDto>(res);
        }
        throw new NotFoundException("Data not found while RemoveItemFromCart");
    }

    public async Task<CartResponseDto> UpdateItemQuantityInCart(long cartId, long itemId, int newQuantity)
    {
        var res = await _cartRepository.UpdateItemQuantityInCart(cartId, itemId,newQuantity);
        if (res is not null)
        {
            return _map.Map<CartResponseDto>(res);
        }
        throw new NotFoundException("Data not found while RemoveItemFromCart");
    }

    public async Task<List<ItemResponseDto>> ValidateCartItemsAvailability(long cartId)
    {
        var res = await _cartRepository.ValidateCartItemsAvailability(cartId);
        if (res is not null)
        {
            return _map.Map<List<ItemResponseDto>>(res);
        }
        throw new NotFoundException("Data not found while RemoveItemFromCart");
    }
}
