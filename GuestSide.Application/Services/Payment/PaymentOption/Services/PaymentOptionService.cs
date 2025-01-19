using AutoMapper;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.PaymentOption;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.Services;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Payment.PaymentOption.Services;

public class PaymentOptionService : GenericService<PaymentOptionDto, PaymentOptionResponseDto, long, Core.Entities.Payment.PaymentOption>, IPaymentOption
{
    public PaymentOptionService(IMapper mapper,
        IGenericRepository<Core.Entities.Payment.PaymentOption> repository, 
        ILogger<GenericService<PaymentOptionDto, PaymentOptionResponseDto, long, Core.Entities.Payment.PaymentOption>> logger,
        IAdditioalFeatures<Core.Entities.Payment.PaymentOption> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
