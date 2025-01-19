using Core.Core.Interfaces.Restaurant;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Restaurant;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant
{
    public class RestaurantRepository : GenericRepository<GuestSide.Core.Entities.Restaurant.Restaurants>, IRestaurantRepository
    {
        public RestaurantRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Restaurants> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
