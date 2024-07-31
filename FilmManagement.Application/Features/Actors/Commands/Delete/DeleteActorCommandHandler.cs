using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Dtos;
using FilmManagement.Application.Features.Actors.Rules;
using FilmManagement.Domain.Entities;
using MediatR;

namespace FilmManagement.Application.Features.Actors.Commands.Delete
{
    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommandRequest, ApiResponse<DeleteActorResponseDto>>
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        private readonly ActorBusinessRules _actorBusinessRules;

        public DeleteActorCommandHandler(IActorService actorService, IMapper mapper, ActorBusinessRules actorBusinessRules)
        {
            _actorService = actorService;
            _mapper = mapper;
            _actorBusinessRules = actorBusinessRules;
        }
        public async Task<ApiResponse<DeleteActorResponseDto>> Handle(DeleteActorCommandRequest request, CancellationToken cancellationToken)
        {
            await _actorBusinessRules.ActorShouldExistWhenUpdated(request.Id);

            ApiResponse<Actor?> getActorResponse = await _actorService.GetAsync(d => d.Id == request.Id);

            Actor? actor = _mapper.Map(request, getActorResponse.Data);

            ApiResponse<Actor> deletedActor = await _actorService.DeleteAsync(actor);

            DeleteActorResponseDto responseDto = _mapper.Map<DeleteActorResponseDto>(deletedActor.Data);
            return new ApiResponse<DeleteActorResponseDto>(responseDto, deletedActor.Message);
        }
    }
}