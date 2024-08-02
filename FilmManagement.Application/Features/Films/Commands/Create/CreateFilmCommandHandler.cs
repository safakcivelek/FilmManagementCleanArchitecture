using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Rules;
using FilmManagement.Application.Features.Directors.Rules;
using FilmManagement.Application.Features.Films.Dtos;
using FilmManagement.Application.Features.Films.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Films.Commands.Create
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommandRequest, ApiResponse<CreateFilmResponseDto>>
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;
        private readonly FilmBusinessRules _filmBusinessRules;
        private readonly DirectorBusinessRules _directorBusinessRules;
        private readonly ActorBusinessRules _actorBusinessRules;

        public CreateFilmCommandHandler(IMapper mapper, IFilmService filmService, FilmBusinessRules filmBusinessRules, DirectorBusinessRules directorBusinessRules, ActorBusinessRules actorBusinessRules)
        {
            _mapper = mapper;
            _filmService = filmService;
            _filmBusinessRules = filmBusinessRules;
            _directorBusinessRules = directorBusinessRules;
            _actorBusinessRules = actorBusinessRules;
        }

        public async Task<ApiResponse<CreateFilmResponseDto>> Handle(CreateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            //Film Süresi gibi doğrulama kontrolleride yapılabilir.

            await _filmBusinessRules.FilmNameShouldNotExistsWhenInsert(request.Name);
            await _filmBusinessRules.ActorsShouldExistWhenInsert(request.ActorIds);
            await _filmBusinessRules.DirectorShouldExistWhenInsert(request.DirectorId);
            //genre için doğrulama yazılacak. 0,


            Film film = _mapper.Map<Film>(request);

            film.FilmGenres = request.GenreIds.Select(genreId => new FilmGenre
            {
                GenreId = genreId,
                CreatedDate = DateTime.Now
            }).ToList();

            film.FilmActors = request.ActorIds.Select(actorId => new FilmActor
            {
                ActorId = actorId,
                CreatedDate = DateTime.Now
            }).ToList(); 

            ApiResponse<Film> addedFilm = await _filmService.AddAsync(film);

            CreateFilmResponseDto responseDto = _mapper.Map<CreateFilmResponseDto>(addedFilm.Data);
            return new ApiResponse<CreateFilmResponseDto>(responseDto, addedFilm.Message);           
        }
    }
}
