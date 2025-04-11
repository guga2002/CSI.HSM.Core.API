using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.PaymentOption;
using Core.Application.Services.Payment.RestaurantOrderPayment.Mapper;
using Core.Application.Services.Payment.RestaurantOrderPayment.Services;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Restaurant.Payment;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Restaurant.Payment;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Payment.RestaurantOrderPayment.DI;

public static class RestaurantOrderPaymentDi
{
    public static void InjectRestaurantOrderPaymen(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Domain.Core.Entities.Payment.RestaurantOrderPayment>, RestaurantOrderPaymentRepository>();
        services.AddScoped<IRestaurantOrderPaymentRepository, RestaurantOrderPaymentRepository>();
        services.AddScoped<IRestaurantOrderPayment, RestaurantOrderPaymentService>();
        services.AddScoped<IService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Domain.Core.Entities.Payment.RestaurantOrderPayment>,RestaurantOrderPaymentService>();
        services.AddScoped<IAdditionalFeatures<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Domain.Core.Entities.Payment.RestaurantOrderPayment>, RestaurantOrderPaymentService>();
        services.AddAutoMapper(typeof(RestaurantOrderPaymetnMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Domain.Core.Entities.Payment.RestaurantOrderPayment>, AdditionalFeaturesRepository<Domain.Core.Entities.Payment.RestaurantOrderPayment>>();
    }
}
