using FluentValidation;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;

namespace GuestSide.Application.FluentValidation.Advertisment
{
    public class AdvertismentTypeValidator:AbstractValidator<AdvertisementTypeResponseDto>
    {
        public AdvertismentTypeValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull().WithMessage("Name is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .MinimumLength(3).WithMessage("Description must be at least 3 characters long.");
        }
    }
}
