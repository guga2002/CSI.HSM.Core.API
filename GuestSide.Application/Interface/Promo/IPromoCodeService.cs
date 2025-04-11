using Core.Application.DTOs.Request.Promo;
using Core.Application.DTOs.Response.Promo;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Promo;

namespace Core.Application.Interface.Promo;

public interface IPromoCodeService : IService<PromoCodeDto, PromoCodeResponse, long, PromoCode>,
IAdditionalFeatures<PromoCodeDto, PromoCodeResponse, long, PromoCode>
{
    Task<PromoCodeResponse> ValidatePromoCodeAsync(string code, long? guestId = null, long? cartId = null, CancellationToken cancellationToken = default);
    Task<int> DeactivateExpiredPromoCodesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<PromoCodeResponse>> GetAvailableForGuestAsync(long guestId, CancellationToken cancellationToken = default);
    Task<IEnumerable<PromoCodeResponse>> GetAvailableForItemAsync(long itemId, CancellationToken cancellationToken = default);
}
