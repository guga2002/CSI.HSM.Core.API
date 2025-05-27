using AutoMapper;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;

namespace Core.Application.Services.Payment.RestaurantOrderPayment.Mapper;

public class RestaurantOrderPaymetnMapper : Profile
{
    public RestaurantOrderPaymetnMapper()
    {
        CreateMap<RestaurantOrderPaymentDto, Common.Data.Entities.Payment.RestaurantOrderPayment>().ReverseMap();
        CreateMap<Common.Data.Entities.Payment.RestaurantOrderPayment, RestaurantOrderPaymentResponseDto>().ReverseMap();
    }
}
