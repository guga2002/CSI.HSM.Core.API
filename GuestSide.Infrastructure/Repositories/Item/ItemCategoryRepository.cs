using Core.Core.Data;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.Item;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item
{
    public class ItemCategoryRepository : GenericRepository<ItemCategory>, IItemCategoryRepository
    {
        public ItemCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<ItemCategory> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
