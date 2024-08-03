// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Authors.Commands.RemoveAuthor
{
    public class RemoveAuthorCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<RemoveAuthorCommand>
    {
        public async Task Handle(RemoveAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = await authorRepository.GetAuthorAsync(command.AuthorId)
                ?? throw new NotFoundException(nameof(Author), command.AuthorId);

            // TODO: Ensure no books are associated with the author before deleting. -OR- update mapping to 'unspecified'.

            await authorRepository.DeleteAuthorAsync(author);
        }
    }
}
