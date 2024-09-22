using FluentValidation;
using GuestSide.Application.DTOs.Advertisment;

namespace GuestSide.Application.FluentValidation.Advertisment
{
    public class AdventismentValidator:AbstractValidator<AdvertismentDto>
    {
        public AdventismentValidator()
        {
            RuleFor(x => x.Title).NotEmpty()
                .NotNull().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long."); 

            RuleFor(x => x.Description).NotEmpty()
                .NotNull().WithMessage("Name is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .MinimumLength(3).WithMessage("Description must be at least 3 characters long.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate is required.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate is required.")
                .GreaterThanOrEqualTo(x=>x.StartDate).WithMessage("End date must be after or equal to the start date.");
        }
    }
}
