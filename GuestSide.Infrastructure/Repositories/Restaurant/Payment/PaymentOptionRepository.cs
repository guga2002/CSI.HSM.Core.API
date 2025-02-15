using Core.Core.Data;
using Core.Core.Entities.Payment;
using Core.Core.Interfaces.Restaurant.Payment;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant.Payment;

public class PaymentOptionRepository : GenericRepository<PaymentOption>, IPaymentOptionRepository
{
    public PaymentOptionRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<PaymentOption> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
