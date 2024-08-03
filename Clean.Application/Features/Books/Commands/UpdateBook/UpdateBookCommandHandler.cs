// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository) : IRequestHandler<UpdateBookCommand>
    {
        public async Task Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetBookAsync(command.BookId)
                ?? throw new NotFoundException(nameof(Book), command.BookId);

            var validator = new UpdateBookCommandValidator();
            var validationResults = await validator.ValidateAsync(command, cancellationToken);

            if (validationResults.Errors.Count > 0)
            {
                throw new ValidationException(validationResults);
            }

            mapper.Map(command, book, typeof(UpdateBookCommand), typeof(Book));

            await bookRepository.UpdateBookAsync(book);
        }
    }
}
