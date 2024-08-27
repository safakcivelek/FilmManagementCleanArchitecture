using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;


namespace FilmManagement.Application.Features.Genres.Queries.GetList
{
    public class GetListGenreQueryHandler : IRequestHandler<GetListGenreQueryRequest, ApiPagedResponse<GetListGenreResponseDto>>
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GetListGenreQueryHandler(IMapper mapper, IGenreService genreService)
        {
            _mapper = mapper;
            _genreService = genreService;
        }
        public async Task<ApiPagedResponse<GetListGenreResponseDto>> Handle(GetListGenreQueryRequest request, CancellationToken cancellationToken)
        {
            ApiPagedResponse<Genre> getGenresResponse = await _genreService.GetListAsync(
                 withDeleted: false,
                 enableTracking: false
                 );

            IList<GetListGenreResponseDto> responseDto = _mapper.Map<IList<GetListGenreResponseDto>>(getGenresResponse.Data);
            return new ApiPagedResponse<GetListGenreResponseDto>(responseDto, getGenresResponse.Message);
        }
    }
}
