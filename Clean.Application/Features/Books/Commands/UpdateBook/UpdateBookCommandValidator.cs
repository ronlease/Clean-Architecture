// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using FluentValidation;

namespace Clean.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.BookId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(b => b.Title)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
