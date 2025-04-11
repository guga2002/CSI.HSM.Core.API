using AutoMapper;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.PaymentOption;
using Core.Application.Services;
using Domain.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Payment.PaymentOption.Services;

public class PaymentOptionService : GenericService<PaymentOptionDto, PaymentOptionResponseDto, long, Core.Entities.Payment.PaymentOption>, IPaymentOption
{
    public PaymentOptionService(IMapper mapper,
        IGenericRepository<Core.Entities.Payment.PaymentOption> repository,
        ILogger<GenericService<PaymentOptionDto, PaymentOptionResponseDto, long, Core.Entities.Payment.PaymentOption>> logger,
        IAdditionalFeaturesRepository<Core.Entities.Payment.PaymentOption> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
