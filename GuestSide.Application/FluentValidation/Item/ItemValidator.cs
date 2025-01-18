using FluentValidation;
using GuestSide.Application.DTOs.Request.Item;

namespace GuestSide.Application.FluentValidation.Item
{
    public class ItemValidator:AbstractValidator<ItemDto>
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
