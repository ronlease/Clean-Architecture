// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Entities;

namespace Clean.Application.Contracts.Persistence
{
    public interface IBookRepository
    {
        Task<Book> CreateBookAsync(Book book);

        Task DeleteBookAsync(Book book);

        Task<bool> IsBookUniqueAsync(int authorId, string title, int yearPublished);

        Task<Book> GetBookAsync(int id);

        Task<IReadOnlyCollection<Book>> GetBooksAsync();

        Task UpdateBookAsync(Book book);
    }
}
