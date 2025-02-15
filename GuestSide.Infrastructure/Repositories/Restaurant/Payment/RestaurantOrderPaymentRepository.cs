using Core.Core.Data;
using Core.Core.Entities.Payment;
using Core.Core.Interfaces.Restaurant.Payment;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant.Payment;

public class RestaurantOrderPaymentRepository : GenericRepository<RestaurantOrderPayment>, IRestaurantOrderPaymentRepository
{
    public RestaurantOrderPaymentRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantOrderPayment> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
