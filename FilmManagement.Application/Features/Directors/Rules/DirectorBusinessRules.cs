using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Directors.Constants;
using FilmManagement.Application.Rules;

namespace FilmManagement.Application.Features.Directors.Rules
{
    public class DirectorBusinessRules : BaseBusinessRules
    {
        private readonly IDirectorService _directorService;
        public DirectorBusinessRules(IDirectorService directorService)
        {
            _directorService = directorService;
        }       

        // Yönetmen güncellenirken var olması gerekir
        public async Task DirectorShouldExistWhenUpdated(Guid id)
        {
            bool doesExists = await _directorService.AnyAsync(f => f.Id == id);
            if (!doesExists)
                throw new NotFoundException(DirectorBusinessMessages.DirectorNotFound);
        }

        // Yönetmen silinirken var olması gerekir
        public async Task DirectorShouldExistWhenDeleted(Guid id)
        {
            bool doesExists = await _directorService.AnyAsync(f => f.Id == id);
            if (!doesExists)
                throw new NotFoundException(DirectorBusinessMessages.DirectorNotFound);
        }
    }
}
