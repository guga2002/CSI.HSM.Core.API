using Core.Core.Data;
using Core.Core.Entities.Restaurant;
using Core.Core.Interfaces.Restaurant;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant;

public class RestaurantCartRepository : GenericRepository<RestaurantCart>, IRestaurantCartRepository
{
    public RestaurantCartRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantCart> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
