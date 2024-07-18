// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Entities;

namespace Clean.Application.Contracts.Persistence
{
    public interface IGenreRepository
    {
        Task DeleteGenreAsync(Genre genre);

        Task<Genre> GetGenreAsync(int id);

        Task<IReadOnlyCollection<Genre>> GetGenresAsync();

        Task UpdateGenreAsync(Genre genre);
    }
}
