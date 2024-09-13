// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Books.Commands.RemoveBook
{
    public class RemoveBookCommand : IRequest
    {
        public int BookId { get; set; }
    }
}
