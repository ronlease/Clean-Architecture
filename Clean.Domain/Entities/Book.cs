// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Common;

namespace Clean.Domain.Entities
{
    public class Book : BaseEntity
    {
        public required int AuthorId { get; set; }

        public required int BookId { get; set; }

        public required string Title { get; set; }

        public int YearPublished { get; set; }

        public virtual Author? Author { get; set; }
    }
}
