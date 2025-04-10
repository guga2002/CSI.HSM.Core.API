using Core.Application.DTOs.Request.Payment;
using Core.Application.DTOs.Response.Payment;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.PaymentOption;

public interface IPaymentOption : IService<PaymentOptionDto, PaymentOptionResponseDto, long, Domain.Core.Entities.Payment.PaymentOption>,
IAdditionalFeatures<PaymentOptionDto, PaymentOptionResponseDto, long, Domain.Core.Entities.Payment.PaymentOption>
{
}
