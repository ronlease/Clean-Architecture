// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository) : IRequestHandler<UpdateAuthorCommand>
    {
        public async Task Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = await authorRepository.GetAuthorAsync(command.AuthorId)
                ?? throw new NotFoundException(nameof(Author), command.AuthorId);

            var validator = new UpdateAuthorCommandValidator();
            var validationResults = await validator.ValidateAsync(command, cancellationToken);

            if (validationResults.Errors.Count > 0)
            {
                throw new ValidationException(validationResults);
            }

            mapper.Map(command, author, typeof(UpdateAuthorCommand), typeof(Author));

            await authorRepository.UpdateAuthorAsync(author);
        }
    }
}
