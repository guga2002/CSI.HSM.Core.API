using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Payment;
using Domain.Core.Interfaces.Restaurant.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant.Payment;

public class RestaurantOrderPaymentRepository : GenericRepository<RestaurantOrderPayment>, IRestaurantOrderPaymentRepository
{
    public RestaurantOrderPaymentRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantOrderPayment> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
