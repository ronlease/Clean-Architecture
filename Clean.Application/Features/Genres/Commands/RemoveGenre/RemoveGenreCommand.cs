// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Genres.Commands.RemoveGenre
{
    public class RemoveGenreCommand : IRequest
    {
        public int GenreId { get; set; }
    }
}
