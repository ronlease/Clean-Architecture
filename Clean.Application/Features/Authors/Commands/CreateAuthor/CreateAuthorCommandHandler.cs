// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository) : IRequestHandler<CreateAuthorCommand, int>
    {
        public async Task<int> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateAuthorCommandValidator(authorRepository);
            var result = await validator.ValidateAsync(command, cancellationToken);

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result);
            }

            var author = mapper.Map<Author>(command);
            author = await authorRepository.CreateAuthorAsync(author);

            return author.AuthorId;
        }
    }
}
