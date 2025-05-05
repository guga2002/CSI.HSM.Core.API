using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Restaurant;
using Domain.Core.Interfaces.Restaurant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant
{
    public class RestaurantRepository : GenericRepository<Domain.Core.Entities.Restaurant.Restaurants>, IRestaurantRepository
    {
        public RestaurantRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Restaurants> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
