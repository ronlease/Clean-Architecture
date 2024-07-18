// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using MediatR;

namespace Clean.Application.Features.Genres.Queries.GetGenre
{
    public class GetGenreQueryHandler(IMapper mapper, IGenreRepository genreRepository, IAuthorRepository authorRepository) : IRequestHandler<GetGenreQuery, GenreViewModel>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IGenreRepository _genreRepository = genreRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GenreViewModel> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetGenreAsync(request.GenreId);
            var viewModel = _mapper.Map<GenreViewModel>(genre);

            var authors = (await _authorRepository.GetAuthorsAsync()).Where(a => a.Genres.Any(g => g.GenreId == request.GenreId));
            viewModel.GenreAuthors = _mapper.Map<IEnumerable<GenreAuthorDto>>(authors);

            return viewModel;
        }
    }
}
