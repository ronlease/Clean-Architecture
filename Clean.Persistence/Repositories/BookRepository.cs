// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Repositories
{
    public class BookRepository(CleanDbContext dbContext) : IBookRepository
    {
        public async Task<Book> CreateBookAsync(Book book)
        {
            dbContext.Add(book);
            await dbContext.SaveChangesAsync();

            return book;
        }

        public async Task DeleteBookAsync(Book book)
        {
            dbContext.Remove(book);
            await dbContext.SaveChangesAsync();
        }

        /* Use something like
         *  var buyer = await _context.Buyers
            .Include(b => b.PaymentMethods)
            .Where(b => b.IdentityGuid == identity)
            .SingleOrDefaultAsync();
        maybe?
        */
        public async Task<Book> GetBookAsync(int id) => await dbContext.Books.FindAsync(id) ?? throw new NotFoundException(nameof(Book), id);

        public async Task<IReadOnlyCollection<Book>> GetBooksAsync() => await dbContext.Books.ToListAsync();

        public Task<bool> IsBookUniqueAsync(int authorId, string title, int yearPublished)
        {
            var isUnique = !dbContext.Books.Any(b => b.Author.AuthorId == authorId && b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && b.YearPublished == yearPublished);

            return Task.FromResult(isUnique);
        }

        public async Task UpdateBookAsync(Book book)
        {
            dbContext.Update(book);

            await dbContext.SaveChangesAsync();
        }
    }
}
