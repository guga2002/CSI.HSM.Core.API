using Core.Core.Interfaces.Item;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Item;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Item;

public class OrderableItemRepository : GenericRepository<OrderableItem>, IOrderableItemRepository
{
    public OrderableItemRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<OrderableItem> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
