using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Delete
{
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommandRequest, ApiResponse<DeleteFilmResponseDto>>
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public DeleteFilmCommandHandler(IMapper mapper, IFilmService filmService)
        {
            _mapper = mapper;
            _filmService = filmService;
        }

        public async Task<ApiResponse<DeleteFilmResponseDto>> Handle(DeleteFilmCommandRequest request, CancellationToken cancellationToken)
        {           
            ApiResponse<Film?> getFilmResponse = await _filmService.GetAsync(f => f.Id == request.Id);

            var film = _mapper.Map(request, getFilmResponse.Data);
            ApiResponse<Film> deletedFilm = await _filmService.DeleteAsync(film);

            DeleteFilmResponseDto responseDto = _mapper.Map<DeleteFilmResponseDto>(film);
            return new ApiResponse<DeleteFilmResponseDto>(responseDto, deletedFilm.Message);
        }
    }
}
