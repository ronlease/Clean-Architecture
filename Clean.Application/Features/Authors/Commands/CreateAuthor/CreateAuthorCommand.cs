// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using MediatR;

namespace Clean.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public override string ToString() => $"Author ID: {AuthorId}, First Name: {FirstName}, Last Name: {LastName}";
    }
}
