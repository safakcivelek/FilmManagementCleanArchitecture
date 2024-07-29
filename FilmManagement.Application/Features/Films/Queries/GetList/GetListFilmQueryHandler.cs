using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetList
{
    public class GetListFilmQueryHandler : IRequestHandler<GetListFilmQueryRequest, ApiListResponse<GetListFilmResponseDto>>
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public GetListFilmQueryHandler(IMapper mapper, IFilmService filmService)
        {
            _mapper = mapper;
            _filmService = filmService;
        }

        public async Task<ApiListResponse<GetListFilmResponseDto>> Handle(GetListFilmQueryRequest request, CancellationToken cancellationToken)
        {                
            ApiListResponse<Film> getFilmsResponse = await _filmService.GetListAsync(
                withDeleted: false,
                enableTracking: false
                );

            IList<GetListFilmResponseDto> responseDto = _mapper.Map<IList<GetListFilmResponseDto>>(getFilmsResponse.Data);
            return new ApiListResponse<GetListFilmResponseDto>(responseDto, getFilmsResponse.Message);
        }
    }
}
