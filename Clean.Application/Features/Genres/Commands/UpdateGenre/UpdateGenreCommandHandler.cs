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
        private readonly IGenreRepository _genreRepository = genreRepository;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetGenreAsync(request.GenreId)
                ?? throw new NotFoundException(nameof(Genre), request.GenreId);

            var validator = new UpdateGenreCommandValidator();
            var validationResults = await validator.ValidateAsync(request, cancellationToken);

            if (validationResults.Errors.Count > 0)
            {
                throw new ValidationException(validationResults);
            }

            _mapper.Map(request, genre, typeof(UpdateGenreCommand), typeof(Genre));

            await _genreRepository.UpdateGenreAsync(genre);
        }
    }
}
