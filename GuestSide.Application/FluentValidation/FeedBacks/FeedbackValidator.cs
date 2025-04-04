﻿using Core.Application.DTOs.Request.FeedBacks;
using FluentValidation;

namespace Core.Application.FluentValidation.FeedBacks
{
    public class FeedbackValidator : AbstractValidator<FeedbackDto>
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
        }
    }
}
