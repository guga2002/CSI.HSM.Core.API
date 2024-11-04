using FluentValidation;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;

namespace GuestSide.Application.FluentValidation.Item
{
    public class ItemValidator:AbstractValidator<ItemResponseDto>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
