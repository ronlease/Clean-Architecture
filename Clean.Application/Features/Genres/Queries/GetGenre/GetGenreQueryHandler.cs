// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using MediatR;

namespace Clean.Application.Features.Genres.Queries.GetGenre
{
    public class GetGenreQueryHandler(IMapper mapper, IGenreRepository genreRepository, IAuthorRepository authorRepository) : IRequestHandler<GetGenreQuery, GenreViewModel>
    {
        public async Task<GenreViewModel> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await genreRepository.GetGenreAsync(request.GenreId);
            var viewModel = mapper.Map<GenreViewModel>(genre);

            var authors = (await authorRepository.GetAuthorsAsync()).Where(a => a.Genres.Any(g => g.GenreId == request.GenreId));
            viewModel.GenreAuthors = mapper.Map<IEnumerable<GenreAuthorDto>>(authors);

            return viewModel;
        }
    }
}
