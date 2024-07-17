// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

namespace Clean.Domain.Entities
{
    public class Genre
    {
        public ICollection<Author> Authors { get; set; } = [];

        public ICollection<Book> Books { get; set; } = [];

        public string GenreName { get; set; } = string.Empty;

        public int GenreId { get; set; }
    }
}
