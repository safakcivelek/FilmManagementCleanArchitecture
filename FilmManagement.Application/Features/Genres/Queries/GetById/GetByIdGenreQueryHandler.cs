using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Genres.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;


namespace FilmManagement.Application.Features.Genres.Queries.GetById
{
    public class GetByIdGenreQueryHandler : IRequestHandler<GetByIdGenreQueryRequest, ApiResponse<GetByIdGenreResponseDto>>
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GetByIdGenreQueryHandler(IMapper mapper, IGenreService genreService)
        {
            _mapper = mapper;
            _genreService = genreService;
        }
        public async Task<ApiResponse<GetByIdGenreResponseDto>> Handle(GetByIdGenreQueryRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<Genre?> getGenreResponse = await _genreService.GetAsync(
                 predicate: d => d.Id == request.Id,
                 withDeleted: true,
                 enableTracking: false);

            GetByIdGenreResponseDto responseDto = _mapper.Map<GetByIdGenreResponseDto>(getGenreResponse.Data);
            return new ApiResponse<GetByIdGenreResponseDto>(responseDto, getGenreResponse.Message);
        }
    }
}
