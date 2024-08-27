using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Genres.Constants;
using FilmManagement.Application.Rules;


namespace FilmManagement.Application.Features.Genres.Rules
{
    public class GenreBusinessRules : BaseBusinessRules
    {
        private readonly IGenreService _genreService;
        public GenreBusinessRules(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // Oyuncu güncellenirken var olması gerekir
        public async Task GenreShouldExistWhenUpdated(Guid id)
        {
            bool doesExists = await _genreService.AnyAsync(f => f.Id == id);
            if (!doesExists)
                throw new NotFoundException(GenreBusinessMessages.GenreNotFound);
        }

        // Oyuncu silinirken var olması gerekir
        public async Task GenreShouldExistWhenDeleted(Guid id)
        {
            bool doesExists = await _genreService.AnyAsync(f => f.Id == id);
            if (!doesExists)
                throw new NotFoundException(GenreBusinessMessages.GenreNotFound);
        }
    }
}
