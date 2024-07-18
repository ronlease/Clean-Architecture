// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommand : IRequest
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; } = string.Empty;
    }
}
