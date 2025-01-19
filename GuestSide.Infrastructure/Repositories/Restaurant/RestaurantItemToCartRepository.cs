using Core.Core.Entities.Restaurant;
using Core.Core.Interfaces.Restaurant;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant;

public class RestaurantItemToCartRepository : GenericRepository<RestaurantItemToCart>, IRestaurantItemToCartRepository
{
    public RestaurantItemToCartRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantItemToCartRepository> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
