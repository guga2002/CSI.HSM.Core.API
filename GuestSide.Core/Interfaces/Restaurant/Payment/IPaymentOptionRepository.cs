using Domain.Core.Entities.Payment;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Restaurant.Payment;

public interface IPaymentOptionRepository : IGenericRepository<PaymentOption>
{
}
