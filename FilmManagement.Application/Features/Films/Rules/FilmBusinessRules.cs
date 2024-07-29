using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Films.Constants;
using FilmManagement.Application.Rules;

namespace FilmManagement.Application.Features.Films.Rules
{
    public class FilmBusinessRules : BaseBusinessRules
    {
        private readonly IFilmService _filmService;
        public FilmBusinessRules(IFilmService filmService)
        {
            _filmService = filmService;
        }

        // Film adının ekleme sırasında benzersiz olduğunu doğrular
        public async Task FilmNameShouldNotExistsWhenInsert(string filmName)
        {
            bool doesExists = await _filmService.AnyAsync(predicate: f => f.Name == filmName, enableTracking: false);
            if (doesExists)
                throw new BusinessException(FilmBusinessMessages.FilmNameAlreadyExists);
        }

        // Film güncellenirken var olması gerekir
        public async Task FilmShouldExistWhenUpdated(Guid id)
        {
            bool doesExists = await _filmService.AnyAsync(f => f.Id == id);
            if (!doesExists)          
                throw new NotFoundException(FilmBusinessMessages.FilmNotFound);      
        }        

        // Film silinirken var olması gerekir
        public async Task FilmShouldExistWhenDeleted(Guid id)
        {
            bool doesExists = await _filmService.AnyAsync(f => f.Id == id);
            if (!doesExists)
                throw new NotFoundException(FilmBusinessMessages.FilmNotFound);
        }
    }
}
