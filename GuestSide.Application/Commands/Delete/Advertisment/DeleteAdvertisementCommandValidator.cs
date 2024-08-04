using FluentValidation;

namespace GuestSide.Application.Commands.Delete.Advertisment
{
    public class DeleteAdvertisementCommandValidator : AbstractValidator<DeleteAdvertisementCommand>
    {
        public DeleteAdvertisementCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
