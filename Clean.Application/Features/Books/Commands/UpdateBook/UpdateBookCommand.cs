// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public ICollection<Author> Authors { get; set; } = [];

        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int YearPublished { get; set; }
    }
}
