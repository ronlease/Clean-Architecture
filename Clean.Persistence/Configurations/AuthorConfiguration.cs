// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.Configurations
{
    public class AuthorConfiguration
    {
        public static void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(k => k.AuthorId);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(r => r.Books)
                .WithOne(r => r.Author)
                .HasForeignKey(r => r.AuthorId);
        }
    }
}
