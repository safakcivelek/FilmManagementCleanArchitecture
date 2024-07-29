using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Application.Features.Films.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Update
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommandRequest, ApiResponse<UpdateFilmResponseDto>>
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;
        private readonly FilmBusinessRules _filmBusinessRules;

        public UpdateFilmCommandHandler(IFilmService filmService, IMapper mapper, FilmBusinessRules filmBusinessRules)
        {
            _filmService = filmService;
            _mapper = mapper;
            _filmBusinessRules = filmBusinessRules;
        }

        public async Task<ApiResponse<UpdateFilmResponseDto>> Handle(UpdateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            await _filmBusinessRules.FilmShouldExistWhenUpdated(request.Id);

            ApiResponse<Film?> getFilmResponse = await _filmService.GetAsync(f => f.Id == request.Id);

            Film? film = _mapper.Map(request, getFilmResponse.Data);
            ApiResponse<Film> updatedFilm = await _filmService.UpdateAsync(film);         

            UpdateFilmResponseDto responseDto =_mapper.Map<UpdateFilmResponseDto>(updatedFilm.Data);
            return new ApiResponse<UpdateFilmResponseDto>(responseDto, updatedFilm.Message);
        }
    }
}
