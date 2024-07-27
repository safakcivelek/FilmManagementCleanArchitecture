using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Queries.GetById
{
    public class GetByIdFilmQueryHandler : IRequestHandler<GetByIdFilmQueryRequest, ApiResponse<GetByIdFilmResponseDto>>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public GetByIdFilmQueryHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<GetByIdFilmResponseDto>> Handle(GetByIdFilmQueryRequest request, CancellationToken cancellationToken)
        {
            //enabletracking ?
            Film? film = await _filmRepository.GetAsync(f => f.Id == request.Id);

            //ApiResponse<GetByIdFilmResponseDto> response = _mapper.Map<ApiResponse<GetByIdFilmResponseDto>>(film);
            //return response;

            GetByIdFilmResponseDto filmDto = _mapper.Map<GetByIdFilmResponseDto>(film);
            return new ApiResponse<GetByIdFilmResponseDto>(filmDto, "Film başarıyla getirildi.");
        }
    }
}
