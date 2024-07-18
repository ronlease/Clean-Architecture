// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using AutoMapper;
using Clean.Application.Contracts.Persistence;
using MediatR;

namespace Clean.Application.Features.Genres.Queries.GetGenres
{
    public class GetGenresQueryHandler(IMapper mapper, IGenreRepository repository) : IRequestHandler<GetGenresQuery, IList<GenresViewModel>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenreRepository _repository = repository;

        public async Task<IList<GenresViewModel>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = (await _repository.GetGenresAsync()).OrderBy(g => g.GenreName);

            return _mapper.Map<IList<GenresViewModel>>(genres);
        }
    }
}
