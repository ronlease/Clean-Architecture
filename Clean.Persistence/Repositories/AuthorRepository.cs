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

        public async Task<Author> GetAuthorAsync(int id)
        {
            return await dbContext.Authors
                .Include(b => b.Books)
                .Where(a => a.AuthorId == id)
                .SingleOrDefaultAsync() ?? throw new NotFoundException(nameof(Author), id);
        }

        public async Task<IReadOnlyCollection<Author>> GetAuthorsAsync() => await dbContext.Authors.ToListAsync();

        public Task<bool> IsAuthorUniqueAsync(string firstName, string lastName)
        {
            var isUnique = !dbContext.Authors.Any(a => a.FirstName == firstName && a.LastName == lastName);

            return Task.FromResult(isUnique);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            dbContext.Update(author);

            await dbContext.SaveChangesAsync();
        }
    }
}
