// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using Clean.Domain.Entities;
using FluentValidation;

namespace Clean.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("{PropertyName} must have a value.")
                .MaximumLength(50).WithMessage("{PropertyName} must be 50 or fewer characters.");

            RuleFor(b => b)
                .MustAsync(IsBookUniqueAsync).WithMessage("This book already exists.");
        }

        private async Task<bool> IsBookUniqueAsync(CreateBookCommand command, CancellationToken cancellationToken)
        {
            return await _bookRepository.IsBookUniqueAsync(command.AuthorId, command.Title, command.YearPublished);
        }
    }
}
