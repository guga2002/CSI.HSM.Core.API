using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.PaymentOption;

[Route("api/[controller]")]
[ApiController]
public class PaymentOptionController : CSIControllerBase<PaymentOptionDto, PaymentOptionResponseDto, long, Core.Entities.Payment.PaymentOption>
{
    public PaymentOptionController(IService<PaymentOptionDto, PaymentOptionResponseDto, long, Core.Entities.Payment.PaymentOption> serviceProvider, IAdditionalFeatures<PaymentOptionDto, PaymentOptionResponseDto, long, Core.Entities.Payment.PaymentOption> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
