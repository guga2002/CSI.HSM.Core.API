using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Restaurant;
using Domain.Core.Interfaces.Restaurant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant;

public class RestaunrantItemRepository : GenericRepository<RestaurantItem>, IRestaunrantItemRepository
{
    public RestaunrantItemRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantItem> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
