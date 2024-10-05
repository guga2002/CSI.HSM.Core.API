using GuestSide.Core.Data;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Item
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(GuestSideDb context) : base(context)
        {
        }
    }
}
