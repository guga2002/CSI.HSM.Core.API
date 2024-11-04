using FluentValidation;
using GuestSide.Application.DTOs.Request.LogModel;
using GuestSide.Application.DTOs.Response.LogModel;

namespace GuestSide.Application.FluentValidation.LogValidator
{
    public class LogValidator:AbstractValidator<LogResponseDto>
    {
        public LogValidator()
        {
           
        }
    }
}
