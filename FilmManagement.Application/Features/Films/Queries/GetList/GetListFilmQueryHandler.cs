using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetList
{
    public class GetListFilmQueryHandler : IRequestHandler<GetListFilmQueryRequest, GetListResponse<GetListFilmDto>>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public GetListFilmQueryHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFilmDto>> Handle(GetListFilmQueryRequest request, CancellationToken cancellationToken)
        {
            // enableTracking : false ?
            IList<Film> films = await _filmRepository.GetListAsync();

            GetListResponse<GetListFilmDto> response = _mapper.Map<GetListResponse<GetListFilmDto>>(films);
            return response;
        }
    }
}
