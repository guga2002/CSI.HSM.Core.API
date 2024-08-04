using FluentValidation;

namespace GuestSide.Application.Commands.Update.Advertisment
{
    public class UpdateAdvertisementCommandValidator : AbstractValidator<UpdateAdvertisementCommand>
    {
        public UpdateAdvertisementCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(x => x.MediaUrl)
                .NotEmpty().WithMessage("MediaUrl is required.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Invalid MediaUrl format.");

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate).WithMessage("StartDate must be less than or equal to EndDate.")
                .When(x => x.StartDate.HasValue && x.EndDate.HasValue);
        }
    }
}
