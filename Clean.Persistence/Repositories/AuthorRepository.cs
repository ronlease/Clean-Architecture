// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Repositories
{
    public class AuthorRepository(CleanDbContext dbContext) : IAuthorRepository
    {
        public async Task<Author> CreateAuthorAsync(Author author)
        {
            dbContext.Add(author);
            await dbContext.SaveChangesAsync();

            return author;
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            dbContext.Remove(author);
            await dbContext.SaveChangesAsync();
        }

        /* Use something like
         *  var buyer = await _context.Buyers
            .Include(b => b.PaymentMethods)
            .Where(b => b.IdentityGuid == identity)
            .SingleOrDefaultAsync();
        maybe?
        */
        public async Task<Author> GetAuthorAsync(int id) => await dbContext.Authors.FindAsync(id) ?? throw new NotFoundException(nameof(Author), id);

        public async Task<IReadOnlyCollection<Author>> GetAuthorsAsync() => await dbContext.Authors.ToListAsync();

        public Task<bool> IsAuthorUniqueAsync(string firstName, string lastName)
        {
            var isUnique = !dbContext.Authors.Any(a => a.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && a.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(isUnique);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            dbContext.Update(author);

            await dbContext.SaveChangesAsync();
        }
    }
}
