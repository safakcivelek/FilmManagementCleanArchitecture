using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetList
{
    public class GetListFilmQueryHandler : IRequestHandler<GetListFilmQueryRequest, ApiListResponse<GetListFilmResponseDto>>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public GetListFilmQueryHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<ApiListResponse<GetListFilmResponseDto>> Handle(GetListFilmQueryRequest request, CancellationToken cancellationToken)
        {
            // enableTracking : false ?
            IList<Film> films = await _filmRepository.GetListAsync();
            
            IList<GetListFilmResponseDto> filmDtos = _mapper.Map<IList<GetListFilmResponseDto>>(films);
            return new ApiListResponse<GetListFilmResponseDto>(filmDtos, "Filmler başarıyla getirildi.");          
        }
    }
}
