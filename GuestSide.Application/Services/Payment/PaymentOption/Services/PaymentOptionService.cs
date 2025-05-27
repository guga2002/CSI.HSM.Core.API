using AutoMapper;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.PaymentOption;
using Core.Application.Services;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Payment.PaymentOption.Services;

public class PaymentOptionService : GenericService<PaymentOptionDto, PaymentOptionResponseDto, long, Common.Data.Entities.Payment.PaymentOption>, IPaymentOption
{
    public PaymentOptionService(IMapper mapper,
        IGenericRepository<Common.Data.Entities.Payment.PaymentOption> repository,
        ILogger<GenericService<PaymentOptionDto, PaymentOptionResponseDto, long, Common.Data.Entities.Payment.PaymentOption>> logger,
        IAdditionalFeaturesRepository<Common.Data.Entities.Payment.PaymentOption> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
