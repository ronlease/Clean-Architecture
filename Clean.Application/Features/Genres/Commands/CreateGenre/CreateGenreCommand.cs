// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<int>
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; } = string.Empty;

        public override string ToString() => $"Genre ID: {GenreId}, Name: {GenreName}";
    }
}
