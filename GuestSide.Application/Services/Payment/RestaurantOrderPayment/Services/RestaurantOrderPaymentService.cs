using AutoMapper;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.PaymentOption;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.Services;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Payment.RestaurantOrderPayment.Services;

public class RestaurantOrderPaymentService : GenericService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, GuestSide.Core.Entities.Payment.RestaurantOrderPayment>, IRestaurantOrderPayment
{
    public RestaurantOrderPaymentService(IMapper mapper,
        IGenericRepository<GuestSide.Core.Entities.Payment.RestaurantOrderPayment> repository, 
        ILogger<GenericService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, GuestSide.Core.Entities.Payment.RestaurantOrderPayment>> logger,
        IAdditioalFeatures<GuestSide.Core.Entities.Payment.RestaurantOrderPayment> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
