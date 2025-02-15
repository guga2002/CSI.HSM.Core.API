using Core.Core.Data;
using Core.Core.Entities.Restaurant;
using Core.Core.Interfaces.Restaurant;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant;

public class RestaunrantItemRepository : GenericRepository<Core.Entities.Restaurant.RestaunrantItem>, IRestaunrantItemRepository
{
    public RestaunrantItemRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaunrantItem> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
