using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Actors.Constants;
using FilmManagement.Application.Rules;

namespace FilmManagement.Application.Features.Actors.Rules
{
    public class ActorBusinessRules : BaseBusinessRules
    {
        private readonly IActorService _directorService;
        public ActorBusinessRules(IActorService directorService)
        {
            _directorService = directorService;
        }

        // Oyuncu güncellenirken var olması gerekir
        public async Task ActorShouldExistWhenUpdated(Guid id)
        {
            bool doesExists = await _directorService.AnyAsync(f => f.Id == id);
            if (!doesExists)
                throw new NotFoundException(ActorBusinessMessages.ActorNotFound);
        }

        // Oyuncu silinirken var olması gerekir
        public async Task ActorShouldExistWhenDeleted(Guid id)
        {
            bool doesExists = await _directorService.AnyAsync(f => f.Id == id);
            if (!doesExists)
                throw new NotFoundException(ActorBusinessMessages.ActorNotFound);
        }
    }
}
