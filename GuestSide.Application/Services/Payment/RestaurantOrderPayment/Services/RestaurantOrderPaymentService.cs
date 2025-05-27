using AutoMapper;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.PaymentOption;
using Core.Application.Services;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Payment.RestaurantOrderPayment.Services;

public class RestaurantOrderPaymentService : GenericService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Common.Data.Entities.Payment.RestaurantOrderPayment>, IRestaurantOrderPayment
{
    public RestaurantOrderPaymentService(IMapper mapper,
        IGenericRepository<Common.Data.Entities.Payment.RestaurantOrderPayment> repository,
        ILogger<GenericService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Common.Data.Entities.Payment.RestaurantOrderPayment>> logger,
        IAdditionalFeaturesRepository<Common.Data.Entities.Payment.RestaurantOrderPayment> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
