// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using MediatR;

namespace Clean.Application.Features.Authors.Queries.GetAuthor
{
    public class GetAuthorQueryHandler(IMapper mapper, IAuthorRepository authorRepository, IBookRepository bookRepository) : IRequestHandler<GetAuthorQuery, AuthorViewModel>
    {
        public async Task<AuthorViewModel> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await authorRepository.GetAuthorAsync(request.AuthorId);
            var viewModel = mapper.Map<AuthorViewModel>(author);

            // TODO: Load the books

            return viewModel;
        }
    }
}
