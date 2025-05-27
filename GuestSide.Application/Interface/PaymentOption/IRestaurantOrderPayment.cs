using Common.Data.Entities.Payment;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.PaymentOption;

public interface IRestaurantOrderPayment : IService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, RestaurantOrderPayment>,
IAdditionalFeatures<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, RestaurantOrderPayment>
{
}
