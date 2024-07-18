// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Genres.Queries.GetGenre
{
    public class GetGenreQuery : IRequest<GenreViewModel>
    {
        public int GenreId { get; set; }
    }
}
