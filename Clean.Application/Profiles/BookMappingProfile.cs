// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Features.Authors.Queries.GetAuthor;
using Clean.Application.Features.Books.Commands.CreateBook;
using Clean.Application.Features.Books.Commands.RemoveBook;
using Clean.Application.Features.Books.Commands.UpdateBook;
using Clean.Application.Features.Books.Queries.GetBook;
using Clean.Application.Features.Books.Queries.GetBooks;
using Clean.Domain.Entities;

namespace Clean.Application.Profiles
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, AuthorBookDto>();
            CreateMap<Book, BookAuthorDto>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Book, BooksViewModel>().ReverseMap();
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, RemoveBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();

            // TODO: Tidy mappings before going live.
        }
    }
}
