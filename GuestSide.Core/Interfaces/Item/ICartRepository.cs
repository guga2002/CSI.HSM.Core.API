using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Item
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<bool> ClearCart(long cartId);
        Task<Cart?> CartSymmary(long cartId);
        Task<Cart> RemoveItemFromCart(long cartId, long itemId);
        Task<List<Items>> ValidateCartItemsAvailability(long cartId);
        Task<Cart> UpdateItemQuantityInCart(long cartId, long itemId, int newQuantity);
        Task<IEnumerable<Cart>> GetCartByGuestId(long guestId, bool status);
        Task<Cart> GetLatestActiveCartForGuestAsync(long guestId);
    }
}