using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Create
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommandRequest, ApiResponse<CreateFilmResponseDto>>
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public CreateFilmCommandHandler(IMapper mapper, IFilmService filmService)
        {
            _mapper = mapper;
            _filmService = filmService;
        }

        public async Task<ApiResponse<CreateFilmResponseDto>> Handle(CreateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            Film film = _mapper.Map<Film>(request);
            ApiResponse<Film> addedFilm = await _filmService.AddAsync(film);

            CreateFilmResponseDto responseDto = _mapper.Map<CreateFilmResponseDto>(addedFilm.Data);
            return new ApiResponse<CreateFilmResponseDto>(responseDto, addedFilm.Message);
        }
    }
}
