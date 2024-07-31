using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Commands.Update;
using FilmManagement.Application.Features.Actors.Dtos;
using FilmManagement.Application.Features.Actors.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Commands.Update
{
    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommandRequest, ApiResponse<UpdateActorResponseDto>>
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        private readonly ActorBusinessRules _actorBusinessRules;

        public UpdateActorCommandHandler(IActorService actorService, IMapper mapper, ActorBusinessRules actorBusinessRules)
        {
            _actorService = actorService;
            _mapper = mapper;
            _actorBusinessRules = actorBusinessRules;
        }

        public async Task<ApiResponse<UpdateActorResponseDto>> Handle(UpdateActorCommandRequest request, CancellationToken cancellationToken)
        {
            await _actorBusinessRules.ActorShouldExistWhenUpdated(request.Id);

            ApiResponse<Actor?> getActorResponse = await _actorService.GetAsync(d => d.Id == request.Id);

            Actor? actor = _mapper.Map(request, getActorResponse.Data);
            ApiResponse<Actor> updatedActor = await _actorService.UpdateAsync(actor);

            UpdateActorResponseDto responseDto = _mapper.Map<UpdateActorResponseDto>(updatedActor.Data);
            return new ApiResponse<UpdateActorResponseDto>(responseDto, updatedActor.Message);
        }
    }
}