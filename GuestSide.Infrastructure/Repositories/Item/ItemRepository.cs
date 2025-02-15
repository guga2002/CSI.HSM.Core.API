using Core.Core.Data;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.Item;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item
{
    public class ItemRepository : GenericRepository<Items>, IItemRepository
    {
        public ItemRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Items> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        public async override Task<IEnumerable<Items>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Include(io => io.ItemCategory).ToListAsync(cancellationToken);
        }
    }
}
