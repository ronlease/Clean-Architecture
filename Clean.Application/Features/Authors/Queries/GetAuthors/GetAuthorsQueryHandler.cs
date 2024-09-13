// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using MediatR;

namespace Clean.Application.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsQueryHandler(IMapper mapper, IAuthorRepository authorRepository) : IRequestHandler<GetAuthorsQuery, IList<AuthorsViewModel>>
    {
        public async Task<IList<AuthorsViewModel>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = (await authorRepository.GetAuthorsAsync()).OrderBy(a => a.LastName);

            return mapper.Map<IList<AuthorsViewModel>>(authors);
        }
    }
}
