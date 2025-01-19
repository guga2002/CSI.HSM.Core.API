using Core.Core.Interfaces.Restaurant;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Restaurant;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant;

public class RestaurantCartRepository : GenericRepository<GuestSide.Core.Entities.Restaurant.RestaurantCart>, IRestaurantCartRepository
{
    public RestaurantCartRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantCart> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
