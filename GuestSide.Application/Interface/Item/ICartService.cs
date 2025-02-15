using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;

namespace Core.Application.Interface.Item;

public interface ICartService : IService<CartDto, CartResponseDto, long, Cart>,
    IAdditionalFeatures<CartDto, CartResponseDto, long, Cart>
{

    Task<bool> ClearCart(long cartId);
    Task<CartResponseDto?> CartSymmary(long cartId);
    Task<CartResponseDto> RemoveItemFromCart(long cartId, long itemId);
    Task<List<ItemResponseDto>> ValidateCartItemsAvailability(long cartId);
    Task<CartResponseDto> UpdateItemQuantityInCart(long cartId, long itemId, int newQuantity);
    Task<IEnumerable<CartResponseDto>> GetCartsByGuestId(long guestId, bool status);
}
