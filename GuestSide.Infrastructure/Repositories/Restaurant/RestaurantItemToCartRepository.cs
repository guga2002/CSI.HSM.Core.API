using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Restaurant;
using Domain.Core.Interfaces.Restaurant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant;

public class RestaurantItemToCartRepository : GenericRepository<RestaurantItemToCart>, IRestaurantItemToCartRepository
{
    public RestaurantItemToCartRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantItemToCart> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
