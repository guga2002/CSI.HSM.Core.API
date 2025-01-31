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
    public class ItemRepository : GenericRepository<Items>, IItemRepository
    {
        public ItemRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Items> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async override Task<IEnumerable<Items>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Include(io=>io.ItemCategory).ToListAsync(cancellationToken);
        }
    }
}
