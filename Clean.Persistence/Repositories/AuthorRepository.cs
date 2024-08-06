// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using Clean.Domain.Entities;

namespace Clean.Persistence.Repositories
{
    public class AuthorRepository(CleanDbContext dbContext) : IAuthorRepository
    {
        public Task<Author> CreateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Author>> GetAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAuthorUniqueAsync(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
