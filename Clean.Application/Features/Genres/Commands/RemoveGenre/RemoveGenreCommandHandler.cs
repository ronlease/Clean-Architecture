// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Genres.Commands.RemoveGenre
{
    public class RemoveGenreCommandHandler(IMapper mapper, IGenreRepository genreRepository) : IRequestHandler<RemoveGenreCommand>
    {
        private readonly IGenreRepository _genreRepository = genreRepository;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(RemoveGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetGenreAsync(request.GenreId) 
                ?? throw new NotFoundException(nameof(Genre), request.GenreId);

            // TODO: Ensure no books or authors are associated with the genre before deleting. -OR- updating mapping to 'unspecified'.

            await _genreRepository.DeleteGenreAsync(genre);
        }
    }
}
