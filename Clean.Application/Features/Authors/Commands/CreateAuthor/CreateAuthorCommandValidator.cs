// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using FluentValidation;

namespace Clean.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("{PropertyName} must have a value.")
                .MaximumLength(50).WithMessage("{PropertyName} must be 50 or fewer characters.");

            RuleFor(a => a.LastName)
                .NotEmpty().WithMessage("{PropertyName} must have a value.")
                .MaximumLength(50).WithMessage("{PropertyName} must be 50 or fewer characters.");

            RuleFor(a => a)
                .MustAsync(IsAuthorUniqueAsync).WithMessage("This author already exists.");
        }

        private async Task<bool> IsAuthorUniqueAsync(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            return await _authorRepository.IsAuthorUniqueAsync(command.FirstName, command.LastName);
        }
    }
}
