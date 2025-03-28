﻿using AutoMapper;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.PaymentOption;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Payment.RestaurantOrderPayment.Services;

public class RestaurantOrderPaymentService : GenericService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Core.Entities.Payment.RestaurantOrderPayment>, IRestaurantOrderPayment
{
    public RestaurantOrderPaymentService(IMapper mapper,
        IGenericRepository<Core.Entities.Payment.RestaurantOrderPayment> repository, 
        ILogger<GenericService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Core.Entities.Payment.RestaurantOrderPayment>> logger,
        IAdditionalFeaturesRepository<Core.Entities.Payment.RestaurantOrderPayment> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
