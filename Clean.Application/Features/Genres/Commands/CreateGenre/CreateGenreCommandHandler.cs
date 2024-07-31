// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler(IMapper mapper, IGenreRepository genreRepository) : IRequestHandler<CreateGenreCommand, int>
    {
        public async Task<int> Handle(CreateGenreCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateGenreCommandValidator(genreRepository);
            var result = await validator.ValidateAsync(command, cancellationToken);

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result);
            }

            var genre = mapper.Map<Genre>(command);
            genre = await genreRepository.CreateAsync(genre);

            return genre.GenreId;
        }
    }
}
