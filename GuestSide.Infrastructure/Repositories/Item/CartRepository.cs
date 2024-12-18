using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Item
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(GuestSideDb context, IRedisCash redisCache) : base(context, redisCache)
        {
        }

        public async override Task<IEnumerable<Cart>> GetAllAsync(CancellationToken cancellationToken = default)
        {
           return await Context.Carts.Include(io=>io.Tasks).ToListAsync(cancellationToken);
        }
    }
}
