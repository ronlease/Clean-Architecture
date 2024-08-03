// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Books.Commands.RemoveBook
{
    public class RemoveBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<RemoveBookCommand>
    {
        public async Task Handle(RemoveBookCommand command, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetBookAsync(command.BookId)
                ?? throw new NotFoundException(nameof(Book), command.BookId);

            // TODO: Ensure no authors are associated with the book before deleting. -OR- update mapping to 'unspecified'.

            await bookRepository.DeleteBookAsync(book);
        }
    }
}
