using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Restaurant.Payment;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Restaurant.Payment;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.PaymentOption;
using Core.Application.Services.Payment.PaymentOption.Mapper;
using Core.Application.Services.Payment.PaymentOption.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Payment.PaymentOption.DI;

public static class PaymentOptionDi
{
    public static void InjectPaymentOption(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Common.Data.Entities.Payment.PaymentOption>, PaymentOptionRepository>();
        services.AddScoped<IPaymentOptionRepository, PaymentOptionRepository>();
        services.AddScoped<IPaymentOption, PaymentOptionService>();
        services.AddScoped<IService<PaymentOptionDto, PaymentOptionResponseDto, long, Common.Data.Entities.Payment.PaymentOption>, PaymentOptionService>();
        services.AddScoped<IAdditionalFeatures<PaymentOptionDto, PaymentOptionResponseDto, long, Common.Data.Entities.Payment.PaymentOption>, PaymentOptionService>();
        services.AddAutoMapper(typeof(PaymentOptionMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Common.Data.Entities.Payment.PaymentOption>, AdditionalFeaturesRepository<Common.Data.Entities.Payment.PaymentOption>>();

    }
}
