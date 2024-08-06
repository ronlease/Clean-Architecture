﻿// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Common;

namespace Clean.Domain.Entities
{
    public class Book : BaseEntity
    {
        public Author Author { get; set; } = new Author();

        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int YearPublished { get; set; }
    }
}
