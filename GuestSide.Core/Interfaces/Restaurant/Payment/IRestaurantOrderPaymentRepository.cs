using Core.Core.Entities.Payment;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Restaurant.Payment;

public interface IRestaurantOrderPaymentRepository:IGenericRepository<RestaurantOrderPayment>
{
}
