// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Repositories
{
    public class AuthorRepository(CleanDbContext dbContext) : IAuthorRepository
    {
        public async Task<Author> CreateAuthorAsync(Author author)
        {
            await dbContext.AddAsync(author);
            await dbContext.SaveChangesAsync();

            return author;
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            dbContext.Remove(author);

            await dbContext.SaveChangesAsync();
        }

        public async Task<Author> GetAuthorAsync(int id) => await dbContext.Authors.FindAsync(id) ?? new Author();

        public async Task<IReadOnlyCollection<Author>> GetAuthorsAsync() => await dbContext.Authors.ToListAsync();

        public Task<bool> IsAuthorUniqueAsync(string firstName, string lastName)
        {
            var isUnique = !dbContext.Authors.Any(a => a.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && a.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(isUnique);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            dbContext.Entry(author).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
        }
    }
}
