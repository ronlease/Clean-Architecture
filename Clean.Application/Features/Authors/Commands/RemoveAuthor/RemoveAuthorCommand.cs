// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Authors.Commands.RemoveAuthor
{
    public class RemoveAuthorCommand : IRequest
    {
        public int AuthorId { get; set; }
    }
}
