using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetById
{
    public class GetByIdFilmQueryHandler : IRequestHandler<GetByIdFilmQueryRequest, ApiResponse<GetByIdFilmResponseDto>>
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public GetByIdFilmQueryHandler(IMapper mapper, IFilmService filmService)
        {
            _mapper = mapper;
            _filmService = filmService;
        }

        public async Task<ApiResponse<GetByIdFilmResponseDto>> Handle(GetByIdFilmQueryRequest request, CancellationToken cancellationToken)
        {
            //enabletracking ?          
            ApiResponse<Film?> getFilmResponse = await _filmService.GetAsync(
                predicate: f => f.Id == request.Id,
                withDeleted:true);
            // Silinen ürünü getirmek istersem nasıl hata kontrolü yaparım ? data varmı yokmu kontrolu businessRules

            GetByIdFilmResponseDto responseDto = _mapper.Map<GetByIdFilmResponseDto>(getFilmResponse.Data);
            return new ApiResponse<GetByIdFilmResponseDto>(responseDto, getFilmResponse.Message);
        }
    }
}
