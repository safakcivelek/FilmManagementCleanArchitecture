using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Application.Features.Films.Rules;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            await _filmBusinessRules.DirectorShouldExistWhenInsert(request.DirectorId);
            await _filmBusinessRules.ActorsShouldExistWhenInsert(request.ActorIds);
            await _filmBusinessRules.GenresShouldExistWhenInsert(request.GenreIds);

            var film = await _filmService.GetAsync(f => f.Id == request.Id, include: f => f.Include(f => f.FilmGenres).Include(f => f.FilmActors));

            if (film.Data == null)
                return new ApiResponse<UpdateFilmResponseDto>(null, "Film not found");

            // Film ve ilişkilerini güncelle
            film.Data.FilmGenres.Clear();
            film.Data.FilmActors.Clear();

            film.Data.FilmGenres = request.GenreIds.Select(genreId => new FilmGenre { GenreId = genreId, FilmId = film.Data.Id }).ToList();
            film.Data.FilmActors = request.ActorIds.Select(actorId => new FilmActor { ActorId = actorId, FilmId = film.Data.Id }).ToList();

            _mapper.Map(request, film.Data);

            var updatedFilm = await _filmService.UpdateAsync(film.Data);

            var responseDto = _mapper.Map<UpdateFilmResponseDto>(updatedFilm.Data);
            return new ApiResponse<UpdateFilmResponseDto>(responseDto, updatedFilm.Message);
        }
    }
}
