// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandHandler(IMapper mapper, IGenreRepository genreRepository) : IRequestHandler<UpdateGenreCommand>
    {
        public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await genreRepository.GetGenreAsync(request.GenreId)
                ?? throw new NotFoundException(nameof(Genre), request.GenreId);

            var validator = new UpdateGenreCommandValidator();
            var validationResults = await validator.ValidateAsync(request, cancellationToken);

            if (validationResults.Errors.Count > 0)
            {
                throw new ValidationException(validationResults);
            }

            mapper.Map(request, genre, typeof(UpdateGenreCommand), typeof(Genre));

            await genreRepository.UpdateGenreAsync(genre);
        }
    }
}
