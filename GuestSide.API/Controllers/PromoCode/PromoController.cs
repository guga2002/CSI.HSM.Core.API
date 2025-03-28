using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Promo;
using Core.Application.DTOs.Response.Promo;
using Core.Application.Interface.Promo;
using Core.Application.Interface.GenericContracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.PromoCode;

[ApiController]
[Route("api/[controller]")]
public class PromoController : CSIControllerBase<PromoCodeDto, PromoCodeResponse, long, Core.Entities.Promo.PromoCode>
{
    private readonly IPromoCodeService _promoCodeService;

    public PromoController(
        IPromoCodeService promoCodeService,
        IService<PromoCodeDto, PromoCodeResponse, long, Core.Entities.Promo.PromoCode> serviceProvider,
        IAdditionalFeatures<PromoCodeDto, PromoCodeResponse, long, Core.Entities.Promo.PromoCode> additionalFeatures)
        : base(serviceProvider, additionalFeatures)
    {
        _promoCodeService = promoCodeService;
    }

    [HttpGet("validate/{code}")]
    [SwaggerOperation(Summary = "Validate a promo code", Description = "Checks if the provided promo code is valid for the guest and/or cart.")]
    [ProducesResponseType(typeof(Response<PromoCodeResponse>), StatusCodes.Status200OK)]
    public async Task<Response<PromoCodeResponse>> ValidatePromoCodeAsync([FromRoute] string code, [FromQuery] long? guestId = null, [FromQuery] long? cartId = null, CancellationToken cancellationToken = default)
    {
        var result = await _promoCodeService.ValidatePromoCodeAsync(code, guestId, cartId, cancellationToken);
        return new Response<PromoCodeResponse>(true, result);
    }

    [HttpPost("deactivate-expired")]
    [SwaggerOperation(Summary = "Deactivate expired promo codes", Description = "Disables all promo codes that have expired.")]
    [ProducesResponseType(typeof(Response<int>), StatusCodes.Status200OK)]
    public async Task<Response<int>> DeactivateExpiredPromoCodesAsync(CancellationToken cancellationToken = default)
    {
        var count = await _promoCodeService.DeactivateExpiredPromoCodesAsync(cancellationToken);
        return new Response<int>(true, count);
    }

    [HttpGet("available/guest/{guestId:long}")]
    [SwaggerOperation(Summary = "Get promo codes available for a guest", Description = "Retrieves all promo codes available to a specific guest.")]
    [ProducesResponseType(typeof(Response<IEnumerable<PromoCodeResponse>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<PromoCodeResponse>>> GetAvailableForGuestAsync([FromRoute] long guestId, CancellationToken cancellationToken = default)
    {
        var result = await _promoCodeService.GetAvailableForGuestAsync(guestId, cancellationToken);
        return new Response<IEnumerable<PromoCodeResponse>>(true, result);
    }

    [HttpGet("available/item/{itemId:long}")]
    [SwaggerOperation(Summary = "Get promo codes available for an item", Description = "Retrieves all promo codes available to a specific item.")]
    [ProducesResponseType(typeof(Response<IEnumerable<PromoCodeResponse>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<PromoCodeResponse>>> GetAvailableForItemAsync([FromRoute] long itemId, CancellationToken cancellationToken = default)
    {
        var result = await _promoCodeService.GetAvailableForItemAsync(itemId, cancellationToken);
        return new Response<IEnumerable<PromoCodeResponse>>(true, result);
    }

    [HttpGet]
    public override async Task<Response<IEnumerable<PromoCodeResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    public override async Task<Response<PromoCodeResponse>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    public override async Task<Response<PromoCodeResponse>> CreateAsync([FromBody] PromoCodeDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    public override async Task<Response<PromoCodeResponse>> UpdateAsync([FromRoute] long id, [FromBody] PromoCodeDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    public override async Task<Response<PromoCodeResponse>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    public override async Task<Response<PromoCodeResponse>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<PromoCodeDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<PromoCodeDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<PromoCodeDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }
}
