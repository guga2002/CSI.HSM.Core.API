using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.Item
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Cart> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async override Task<IEnumerable<Cart>> GetAllAsync(CancellationToken cancellationToken = default)
        {
           return await Context.Carts.Include(io=>io.Tasks).ToListAsync(cancellationToken);
        }
    }
}
