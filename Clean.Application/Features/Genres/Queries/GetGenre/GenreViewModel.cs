// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

namespace Clean.Application.Features.Genres.Queries.GetGenre
{
    public class GenreViewModel
    {
        public IEnumerable<GenreAuthorDto> GenreAuthors { get; set; } = [];

        public int GenreId { get; set; }

        public string GenreName { get; set; } = string.Empty;
    }
}
