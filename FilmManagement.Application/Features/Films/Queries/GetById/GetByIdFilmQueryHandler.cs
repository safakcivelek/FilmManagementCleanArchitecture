using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetById
{
    public class GetByIdFilmQueryHandler : IRequestHandler<GetByIdFilmQueryRequest, GetByIdFilmQueryResponse>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public GetByIdFilmQueryHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdFilmQueryResponse> Handle(GetByIdFilmQueryRequest request, CancellationToken cancellationToken)
        {
            //enabletracking ?
            Film film = await _filmRepository.GetAsync(f => f.Id == request.Id);

            GetByIdFilmQueryResponse response = _mapper.Map<GetByIdFilmQueryResponse>(film);
            return response;
        }
    }
}
