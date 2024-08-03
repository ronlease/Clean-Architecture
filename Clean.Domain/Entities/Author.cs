// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Common;

namespace Clean.Domain.Entities
{
    public class Author : BaseEntity
    {
        public int AuthorId { get; set; }

        public ICollection<Book> Books { get; set; } = [];

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
