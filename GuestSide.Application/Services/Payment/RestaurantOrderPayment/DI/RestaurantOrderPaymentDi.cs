using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Restaurant.Payment;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Restaurant.Payment;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.PaymentOption;
using Core.Application.Services.Payment.RestaurantOrderPayment.Mapper;
using Core.Application.Services.Payment.RestaurantOrderPayment.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Payment.RestaurantOrderPayment.DI;

public static class RestaurantOrderPaymentDi
{
    public static void InjectRestaurantOrderPaymen(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Common.Data.Entities.Payment.RestaurantOrderPayment>, RestaurantOrderPaymentRepository>();
        services.AddScoped<IRestaurantOrderPaymentRepository, RestaurantOrderPaymentRepository>();
        services.AddScoped<IRestaurantOrderPayment, RestaurantOrderPaymentService>();
        services.AddScoped<IService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Common.Data.Entities.Payment.RestaurantOrderPayment>, RestaurantOrderPaymentService>();
        services.AddScoped<IAdditionalFeatures<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, Common.Data.Entities.Payment.RestaurantOrderPayment>, RestaurantOrderPaymentService>();
        services.AddAutoMapper(typeof(RestaurantOrderPaymetnMapper));
        services.AddScoped<IAdditionalFeaturesRepository<Common.Data.Entities.Payment.RestaurantOrderPayment>, AdditionalFeaturesRepository<Common.Data.Entities.Payment.RestaurantOrderPayment>>();
    }
}
