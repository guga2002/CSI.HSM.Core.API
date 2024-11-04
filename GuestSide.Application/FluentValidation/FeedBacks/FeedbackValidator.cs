using FluentValidation;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;

namespace GuestSide.Application.FluentValidation.FeedBacks
{
    public class FeedbackValidator:AbstractValidator<FeedbackResponseDto>
    {
        public FeedbackValidator()
        {
            RuleFor(x => x.Title).NotEmpty()
                .NotNull().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long.");

            RuleFor(x => x.Content).NotEmpty()
                .NotNull().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Content cannot exceed 500 characters.")
                .MinimumLength(3).WithMessage("Content must be at least 3 characters long.");

            RuleFor(x => x.FeedbackDate)
                .NotEmpty().WithMessage("FeedbackDate is required.");

            RuleFor(x => x.Rating)
                .NotEmpty().WithMessage("Rating is required.")
                .InclusiveBetween(0,10);
        }
    }
}
