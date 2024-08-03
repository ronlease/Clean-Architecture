// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Features.Authors.Commands.CreateAuthor;
using Clean.Application.Features.Authors.Commands.RemoveAuthor;
using Clean.Application.Features.Authors.Commands.UpdateAuthor;
using Clean.Application.Features.Authors.Queries.GetAuthor;
using Clean.Application.Features.Authors.Queries.GetAuthors;
using Clean.Domain.Entities;

namespace Clean.Application.Profiles
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, AuthorBookDto>().ReverseMap();
            CreateMap<Author, AuthorViewModel>().ReverseMap();
            CreateMap<Author, AuthorsViewModel>().ReverseMap();
            CreateMap<Author, CreateAuthorCommand>().ReverseMap();
            CreateMap<Author, RemoveAuthorCommand>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommand>().ReverseMap();

            // TODO: Tidy mappings before going live.
        }
    }
}
