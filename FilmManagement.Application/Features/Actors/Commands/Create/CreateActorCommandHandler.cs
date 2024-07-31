using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Dtos;
using FilmManagement.Application.Features.Actors.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Commands.Create
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommandRequest, ApiResponse<CreateActorResponseDto>>
    {
        private readonly IActorService _directorService;
        private readonly IMapper _mapper;
        private readonly ActorBusinessRules _actorBusinessRules;

        public CreateActorCommandHandler(IMapper mapper, IActorService directorService, ActorBusinessRules actorBusinessRules)
        {
            _mapper = mapper;
            _directorService = directorService;
            _actorBusinessRules = actorBusinessRules;
        }

        public async Task<ApiResponse<CreateActorResponseDto>> Handle(CreateActorCommandRequest request, CancellationToken cancellationToken)
        {
            Actor actor = _mapper.Map<Actor>(request);
            ApiResponse<Actor> addedActor = await _directorService.AddAsync(actor);

            CreateActorResponseDto responseDto = _mapper.Map<CreateActorResponseDto>(addedActor.Data);
            return new ApiResponse<CreateActorResponseDto>(responseDto, addedActor.Message);
        }
    }
}
