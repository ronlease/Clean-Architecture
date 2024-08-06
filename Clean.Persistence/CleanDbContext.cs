// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Common;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence
{
    public class CleanDbContext(DbContextOptions<CleanDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanDbContext).Assembly);

            var authors = new List<Author>();

            for (int authorId = 1; authorId <= 3; authorId++)
            {
                authors.Add(new Author
                {
                    AuthorId = authorId,
                    FirstName = "Author",
                    LastName = authorId.ToString()
                });
            }

            var books = new List<Book>();

            for (int bookId = 1; bookId <= 6; bookId++)
            {
                books.Add(new Book
                {
                    Author = authors[(bookId % 3) + 1],
                    BookId = bookId,
                    Title = $"Book {bookId}",
                    YearPublished = 2010 + bookId
                });
            }

            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;

                        // TODO: Get user ID if we're going that route.
                        entry.Entity.CreatedBy = 1;
                        entry.Entity.ModifiedOn = DateTime.UtcNow;

                        // TODO: Get user ID if we're going that route.
                        entry.Entity.ModifiedBy = 1;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = DateTime.UtcNow;

                        // TODO: Get user ID if we're going that route.
                        entry.Entity.ModifiedBy = 1;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
