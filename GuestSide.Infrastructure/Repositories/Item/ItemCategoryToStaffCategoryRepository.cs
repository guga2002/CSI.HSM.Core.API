using Core.Core.Entities.Item;
using Core.Core.Interfaces.Item;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item;

public class ItemCategoryToStaffCategoryRepository : GenericRepository<ItemCategoryToStaffCategory>, IItemCategoryToStaffCategory
{
    public ItemCategoryToStaffCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<ItemCategoryToStaffCategory> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
