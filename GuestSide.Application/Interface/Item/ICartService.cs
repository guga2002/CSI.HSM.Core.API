using Common.Data.Entities.Item;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Item
{
    public interface ICartService : IService<CartDto, CartResponseDto, long, Cart>,
        IAdditionalFeatures<CartDto, CartResponseDto, long, Cart>
    {
        /// <summary>
        /// Clear all items in a cart.
        /// </summary>
        Task<bool> ClearCart(long cartId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get cart summary.
        /// </summary>
        Task<CartResponseDto?> CartSummary(long cartId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove an item from the cart.
        /// </summary>
        Task<CartResponseDto> RemoveItemFromCart(long cartId, long itemId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Validate if all items in the cart are available.
        /// </summary>
       // Task<List<ItemResponseDto>> ValidateCartItemsAvailability(long cartId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update item quantity in a cart.
        /// </summary>
        Task<CartResponseDto> UpdateItemQuantityInCart(long cartId, long itemId, int newQuantity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get cart by guest ID.
        /// </summary>
        Task<IEnumerable<CartResponseDto>> GetCartByGuestId(long guestId, bool status, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get latest active cart for a guest.
        /// </summary>
        Task<CartResponseDto?> GetLatestActiveCartForGuestAsync(long guestId, CancellationToken cancellationToken = default);
    }
}