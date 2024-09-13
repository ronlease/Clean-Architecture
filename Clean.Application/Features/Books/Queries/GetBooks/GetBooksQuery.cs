// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Books.Queries.GetBooks
{
    public class GetBooksQuery : IRequest<IList<BooksViewModel>>
    {
    }
}
