// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using MediatR;

namespace Clean.Application.Features.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler(IMapper mapper, IBookRepository bookRepository) : IRequestHandler<GetBooksQuery, IList<BooksViewModel>>
    {
        public async Task<IList<BooksViewModel>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = (await bookRepository.GetBooksAsync()).OrderBy(b => b.Title);

            return mapper.Map<IList<BooksViewModel>>(books);
        }
    }
}
