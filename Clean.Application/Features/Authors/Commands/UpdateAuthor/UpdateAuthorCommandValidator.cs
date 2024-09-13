// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using FluentValidation;

namespace Clean.Application.Features.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(a => a.AuthorId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must be 50 or fewer characters.");

            RuleFor(a => a.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must be 50 or fewer characters.");
        }
    }
}
