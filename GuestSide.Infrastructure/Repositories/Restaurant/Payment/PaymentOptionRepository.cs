using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Payment;
using Domain.Core.Interfaces.Restaurant.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Restaurant.Payment;

public class PaymentOptionRepository : GenericRepository<PaymentOption>, IPaymentOptionRepository
{
    public PaymentOptionRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<PaymentOption> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
