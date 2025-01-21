using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Payment;
using GuestSide.API.CustomExtendControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.PaymentOption;

[Route("api/[controller]")]
[ApiController]
public class RestaurantOrderPaymentController : CSIControllerBase<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, RestaurantOrderPayment>
{
    public RestaurantOrderPaymentController(IService<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, RestaurantOrderPayment> serviceProvider, IAdditionalFeatures<RestaurantOrderPaymentDto, RestaurantOrderPaymentResponseDto, long, RestaurantOrderPayment> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
