using Core.Application.DTOs.Request.LogModel;
using FluentValidation;

namespace Core.Application.FluentValidation.LogValidator
{
    public class LogValidator : AbstractValidator<LogDto>
    {
        public LogValidator()
        {

        }
    }
}
