// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Entities;

namespace Clean.Application.Contracts.Persistence
{
    public interface IGenreRepository
    {
        Task<Genre> GetGenreAsync(int id);

        Task<IReadOnlyCollection<Genre>> GetGenresAsync();

        Task RemoveGenreAsync(Genre genre);

        Task UpdateGenreAsync(Genre genre);
    }
}
