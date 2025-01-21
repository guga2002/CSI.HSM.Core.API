using Core.Core.Entities.Payment;
using Core.Core.Interfaces.Restaurant.Payment;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant.Payment;

public class RestaurantOrderPaymentRepository : GenericRepository<RestaurantOrderPayment>, IRestaurantOrderPaymentRepository
{
    public RestaurantOrderPaymentRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantOrderPayment> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
