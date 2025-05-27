using AutoMapper;
using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;

namespace Core.Application.Services.Payment.PaymentOption.Mapper;

public class PaymentOptionMapper : Profile
{
    public PaymentOptionMapper()
    {
        CreateMap<PaymentOptionDto, Common.Data.Entities.Payment.PaymentOption>().ReverseMap();
        CreateMap<Common.Data.Entities.Payment.PaymentOption, PaymentOptionResponseDto>().ReverseMap();
    }
}
