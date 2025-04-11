using AutoMapper;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.PaymentOption;
using Domain.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Payment.RestaurantOrderPayment.Services;

public class RestaurantOrderPaymentService : GenericService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Domain.Core.Entities.Payment.RestaurantOrderPayment>, IRestaurantOrderPayment
{
    public RestaurantOrderPaymentService(IMapper mapper,
        IGenericRepository<Domain.Core.Entities.Payment.RestaurantOrderPayment> repository, 
        ILogger<GenericService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Domain.Core.Entities.Payment.RestaurantOrderPayment>> logger,
        IAdditionalFeaturesRepository<Domain.Core.Entities.Payment.RestaurantOrderPayment> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
