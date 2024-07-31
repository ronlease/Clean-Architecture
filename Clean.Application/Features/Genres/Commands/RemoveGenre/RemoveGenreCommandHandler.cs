// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Genres.Commands.RemoveGenre
{
    public class RemoveGenreCommandHandler(IGenreRepository genreRepository) : IRequestHandler<RemoveGenreCommand>
    {
        public async Task Handle(RemoveGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await genreRepository.GetGenreAsync(request.GenreId) 
                ?? throw new NotFoundException(nameof(Genre), request.GenreId);

            // TODO: Ensure no books or authors are associated with the genre before deleting. -OR- updating mapping to 'unspecified'.

            await genreRepository.DeleteGenreAsync(genre);
        }
    }
}
