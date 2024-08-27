using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Actors.Constants;
using FilmManagement.Application.Rules;

namespace FilmManagement.Application.Features.Actors.Rules
{
    public class ActorBusinessRules : BaseBusinessRules
    {
        private readonly IActorService _actorService;
        public ActorBusinessRules(IActorService actorService)
        {
            _actorService = actorService;
        }

        // Oyuncu güncellenirken var olması gerekir
        public async Task ActorShouldExistWhenUpdated(Guid id)
        {
            bool doesExists = await _actorService.AnyAsync(f => f.Id == id);
            if (!doesExists)
                throw new NotFoundException(ActorBusinessMessages.ActorNotFound);
        }

        // Oyuncu silinirken var olması gerekir
        public async Task ActorShouldExistWhenDeleted(Guid id)
        {
            bool doesExists = await _actorService.AnyAsync(f => f.Id == id);
            if (!doesExists)
                throw new NotFoundException(ActorBusinessMessages.ActorNotFound);
        }
    }
}
