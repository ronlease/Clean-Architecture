// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

namespace Clean.Application.Features.Books.Queries.GetBooks
{
    public class BooksViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int YearPublished { get; set; }
    }
}
