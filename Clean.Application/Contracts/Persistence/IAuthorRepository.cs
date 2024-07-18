// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Entities;

namespace Clean.Application.Contracts.Persistence
{
    public interface IAuthorRepository
    {
        Task DeleteAuthorAsync(Author author);

        Task<Author> GetAuthorAsync(int id);

        Task<IReadOnlyCollection<Author>> GetAuthorsAsync();

        Task UpdateAuthorAsync(Author author);
    }
}
