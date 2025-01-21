using Core.Core.Entities.Restaurant;
using Core.Core.Interfaces.Restaurant;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant;

public class RestaurantItemCategoryRepository : GenericRepository<Core.Entities.Restaurant.RestaurantItemCategory>, IRestaurantItemCategoryRepository
{
    public RestaurantItemCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantItemCategory> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
