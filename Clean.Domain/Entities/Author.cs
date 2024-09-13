// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Common;

namespace Clean.Domain.Entities
{
    public class Author : BaseEntity
    {
        public required int AuthorId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; } = [];
    }
}
