using FluentValidation;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;

namespace GuestSide.Application.FluentValidation.Guest
{
    public class GuestValidator:AbstractValidator<GuestResponseDto>
    {
        public GuestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .NotNull().WithMessage("FirstName is required.")
                .MaximumLength(200).WithMessage("FirstName cannot exceed 200 characters.")
                .MinimumLength(3).WithMessage("FirstName must be at least 3 characters long.");

            RuleFor(x => x.LastName).NotEmpty()
                .NotNull().WithMessage("LastName is required.")
                .MaximumLength(200).WithMessage("LastName cannot exceed 200 characters.")
                .MinimumLength(3).WithMessage("LastName must be at least 3 characters long.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("PhoneNumber is required.");
        }
    }
}
