﻿// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.Configurations
{
    public class BookConfiguration
    {
        public static void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(k => k.BookId);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(r => r.Author)
                .WithMany(r => r.Books);
        }
    }
}
