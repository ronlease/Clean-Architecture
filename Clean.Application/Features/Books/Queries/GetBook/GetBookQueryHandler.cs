// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using MediatR;

namespace Clean.Application.Features.Books.Queries.GetBook
{
    public class GetBookQueryHandler(IMapper mapper, IBookRepository bookRepository, IAuthorRepository authorRepository) : IRequestHandler<GetBookQuery, BookViewModel>
    {
        public async Task<BookViewModel> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetBookAsync(request.BookId);
            var viewModel = mapper.Map<BookViewModel>(book);

            // TODO: Load the author

            return viewModel;
        }
    }
}
