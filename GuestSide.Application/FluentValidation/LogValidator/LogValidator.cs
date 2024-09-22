using FluentValidation;
using GuestSide.Application.DTOs.Log;

namespace GuestSide.Application.FluentValidation.LogValidator
{
    public class LogValidator:AbstractValidator<LogDto>
    {
        public LogValidator()
        {
           
        }
    }
}
