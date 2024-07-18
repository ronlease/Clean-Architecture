// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Genres.Queries.GetGenres
{
    public class GetGenresQuery : IRequest<IList<GenresViewModel>>
    {
    }
}
