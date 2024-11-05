using FluentValidation;
using GuestSide.Application.DTOs.Request.LogModel;

namespace GuestSide.Application.FluentValidation.LogValidator
{
    public class LogValidator:AbstractValidator<LogDto>
    {
        public LogValidator()
        {
           
        }
    }
}
