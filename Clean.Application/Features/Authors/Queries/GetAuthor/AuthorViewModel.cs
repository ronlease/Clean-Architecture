// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

namespace Clean.Application.Features.Authors.Queries.GetAuthor
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }

        public ICollection<AuthorBookDto> Books { get; set; } = [];

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
