// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using FluentValidation;

namespace Clean.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;

        public CreateGenreCommandValidator(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;

            RuleFor(p => p.GenreName)
                .NotEmpty().WithMessage("{PropertyName} must have a value.")
                .MaximumLength(50).WithMessage("{PropertyName} must be 50 or fewer characters.");

            RuleFor(e => e)
                .MustAsync(IsGenreNameUnique).WithMessage("{PropertyName} already exists.");
        }

        private async Task<bool> IsGenreNameUnique(CreateGenreCommand command, CancellationToken cancellationToken)
        {
            return await _genreRepository.IsGenreNameUniqueAsync(command.GenreName);
        }
    }
}
