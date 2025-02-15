using Core.Core.Data;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.Item;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item;

public class ItemCategoryToStaffCategoryRepository : GenericRepository<ItemCategoryToStaffCategory>, IItemCategoryToStaffCategory
{
    public ItemCategoryToStaffCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<ItemCategoryToStaffCategory> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
