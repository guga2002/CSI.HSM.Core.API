using FluentValidation;
using GuestSide.Application.DTOs.Advertisment;

namespace GuestSide.Application.FluentValidation.Advertisment
{
    public class AdvertismentTypeValidator:AbstractValidator<AdvertisementTypeDto>
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
