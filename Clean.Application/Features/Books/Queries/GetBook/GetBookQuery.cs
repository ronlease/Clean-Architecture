﻿// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Books.Queries.GetBook
{
    public class GetBookQuery : IRequest<BookViewModel>
    {
        public int BookId { get; set; }
    }
}