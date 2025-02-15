using AutoMapper;
using Core.Application.CustomExceptions;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Item;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item.Services;

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
        _map = mapper;
        _cartRepository = cartrep;
    }

    public async Task<CartResponseDto?> CartSymmary(long cartId)
    {
        var res = await _cartRepository.CartSymmary(cartId);
        if (res != null)
        {
            return _map.Map<CartResponseDto>(res);
        }
        throw new NotFoundException("Data not found");
    }

    public async Task<bool> ClearCart(long cartId)
    {
        return await _cartRepository.ClearCart(cartId);
    }

    public async Task<IEnumerable<CartResponseDto>> GetCartsByGuestId(long guestId, bool status)
    {
        var res = await _cartRepository.GetCartByGuestId(guestId, status);
        if (res is not null)
        {
            return _map.Map<IEnumerable<CartResponseDto>>(res);
        }
        throw new NotFoundException("Data not found for that guestId");
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
        var res = await _cartRepository.UpdateItemQuantityInCart(cartId, itemId, newQuantity);
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
