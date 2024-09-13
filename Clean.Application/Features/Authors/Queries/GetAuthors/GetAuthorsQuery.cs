// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsQuery : IRequest<IList<AuthorsViewModel>>
    {
    }
}
