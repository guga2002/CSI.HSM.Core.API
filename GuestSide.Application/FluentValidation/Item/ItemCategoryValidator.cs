using FluentValidation;
using GuestSide.Application.DTOs.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestSide.Application.FluentValidation.Item
{
    public class ItemCategoryValidator:AbstractValidator<ItemCategoryDto>
    {
        public ItemCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");
        }
    }
}
