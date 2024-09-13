// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

namespace Clean.Application.Features.Authors.Queries.GetAuthor
{
    public class AuthorBookDto
    {
        public int BookId { get; set; }

        public string? Title { get; set; }

        public int YearPublished { get; set; }
    }
}
