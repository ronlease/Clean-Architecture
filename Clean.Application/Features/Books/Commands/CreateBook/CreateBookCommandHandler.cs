// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, int>
    {
        public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateBookCommandValidator(bookRepository);
            var result = await validator.ValidateAsync(command, cancellationToken);

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result);
            }

            var book = mapper.Map<Book>(command);
            book = await bookRepository.CreateAsync(book);

            return book.BookId;
        }
    }
}
