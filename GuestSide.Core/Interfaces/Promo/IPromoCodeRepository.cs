using Domain.Core.Entities.Promo;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Promo
{
    public interface IPromoCodeRepository : IGenericRepository<PromoCode>, IAdditionalFeaturesRepository<PromoCode>
    {
        Task<PromoCode> ValidatePromoCodeAsync(string code, long? guestId = null, long? cartId = null, CancellationToken cancellationToken = default);
        Task<int> DeactivateExpiredPromoCodesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<PromoCode>> GetAvailableForGuestAsync(long guestId, CancellationToken cancellationToken = default);
        Task<IEnumerable<PromoCode>> GetAvailableForItemAsync(long itemId, CancellationToken cancellationToken = default);

    }
}
