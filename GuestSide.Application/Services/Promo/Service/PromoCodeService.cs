using AutoMapper;
using Core.Application.DTOs.Request.Promo;
using Core.Application.DTOs.Response.Promo;
using Core.Application.Interface.Promo;
using Core.Core.Entities.Promo;
using Core.Core.Interfaces.Promo;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Promo.Service;

public class PromoCodeService : GenericService<PromoCodeDto, PromoCodeResponse, long, PromoCode>, IPromoCodeService
{
    private readonly IPromoCodeRepository _promoCodeRepository;
    private readonly IMapper _mapper;
    public PromoCodeService(
        IMapper mapper,
        IPromoCodeRepository promoCodeRepository,
        ILogger<GenericService<PromoCodeDto, PromoCodeResponse, long, PromoCode>> logger)
        : base(mapper, promoCodeRepository, logger, promoCodeRepository)
    {
        _mapper = mapper;
        _promoCodeRepository = promoCodeRepository;
    }

    public async Task<int> DeactivateExpiredPromoCodesAsync(CancellationToken cancellationToken = default)
    {
        return await _promoCodeRepository.DeactivateExpiredPromoCodesAsync(cancellationToken);
    }

    public async Task<IEnumerable<PromoCodeResponse>> GetAvailableForGuestAsync(long guestId, CancellationToken cancellationToken = default)
    {
        var promoCodes = await _promoCodeRepository.GetAvailableForGuestAsync(guestId, cancellationToken);
        return _mapper.Map<IEnumerable<PromoCodeResponse>>(promoCodes);
    }

    public async Task<IEnumerable<PromoCodeResponse>> GetAvailableForItemAsync(long itemId, CancellationToken cancellationToken = default)
    {
        var promoCodes = await _promoCodeRepository.GetAvailableForItemAsync(itemId, cancellationToken);
        return _mapper.Map<IEnumerable<PromoCodeResponse>>(promoCodes);
    }

    public async Task<PromoCodeResponse> ValidatePromoCodeAsync(string code, long? guestId = null, long? cartId = null, CancellationToken cancellationToken = default)
    {
        var promoCode = await _promoCodeRepository.ValidatePromoCodeAsync(code, guestId, cartId, cancellationToken);
        return _mapper.Map<PromoCodeResponse>(promoCode);
    }
}
