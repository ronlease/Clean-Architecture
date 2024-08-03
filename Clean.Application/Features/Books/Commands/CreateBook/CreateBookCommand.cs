// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public int AuthorId { get; set; }

        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int YearPublished { get; set; }

        public override string ToString() => $"Book ID: {BookId}, Title: {Title}, Published: {YearPublished}, Author ID: {AuthorId}";
    }
}
