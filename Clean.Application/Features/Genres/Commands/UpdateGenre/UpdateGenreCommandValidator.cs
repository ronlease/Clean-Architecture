// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using FluentValidation;

namespace Clean.Application.Features.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(g => g.GenreId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(g => g.GenreName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
