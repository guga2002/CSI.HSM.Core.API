﻿using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.PaymentOption;
using Core.Application.Services.Payment.PaymentOption.Mapper;
using Core.Application.Services.Payment.PaymentOption.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Restaurant.Payment;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Restaurant.Payment;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Payment.PaymentOption.DI;

public static class PaymentOptionDi
{
    public static void InjectPaymentOption(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Domain.Core.Entities.Payment.PaymentOption>, PaymentOptionRepository>();
        services.AddScoped<IPaymentOptionRepository, PaymentOptionRepository>();
        services.AddScoped<IPaymentOption, PaymentOptionService>();
        services.AddScoped<IService<PaymentOptionDto, PaymentOptionResponseDto, long, Domain.Core.Entities.Payment.PaymentOption>, PaymentOptionService>();
        services.AddScoped<IAdditionalFeatures<PaymentOptionDto, PaymentOptionResponseDto, long, Domain.Core.Entities.Payment.PaymentOption>, PaymentOptionService>();
        services.AddAutoMapper(typeof(PaymentOptionMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Domain.Core.Entities.Payment.PaymentOption>, AdditionalFeaturesRepository<Domain.Core.Entities.Payment.PaymentOption>>();

    }
}
