using Core.Application.DTOs.Request.Item;
using FluentValidation;

namespace Core.Application.FluentValidation.Item
{
    public class ItemValidator : AbstractValidator<ItemDto>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");
        }
    }
}
