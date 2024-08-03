// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Authors.Queries.GetAuthor
{
    public class GetAuthorQuery : IRequest<AuthorViewModel>
    {
        public int AuthorId { get; set; }
    }
}
