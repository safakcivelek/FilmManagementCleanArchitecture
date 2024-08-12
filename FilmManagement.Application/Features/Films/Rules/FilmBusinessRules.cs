using DirectorManagement.Application.Concretes.Services;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Concretes.Services;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Films.Constants;
using FilmManagement.Application.Rules;

namespace FilmManagement.Application.Features.Films.Rules
{
    public class FilmBusinessRules : BaseBusinessRules
    {
        private readonly IFilmService _filmService;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;
        private readonly IDirectorService _directorService;
        public FilmBusinessRules(IFilmService filmService, IGenreService genreService, IActorService actorService, IDirectorService directorService)
        {
            _filmService = filmService;
            _genreService = genreService;
            _actorService = actorService;
            _directorService = directorService;
        }

        //Film Delecelendirme sırasında bulunamadı
        public async Task FilmShouldExistWhenRating(Guid filmId)
        {
            bool doesExist = await _filmService.AnyAsync(f => f.Id == filmId);
            if (!doesExist)
                throw new NotFoundException(FilmBusinessMessages.FilmNotFoundWhenRating);           
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

        // Film eklenirken Genre mevcut olmalı (Genre cqrs tarafı ayarlanınca eklenecek.)
        //public async Task GenresShouldExistWhenInsert(IEnumerable<Guid> genreIds)
        //{
        //    foreach (Guid genreId in genreIds)
        //    {
        //        bool doesExist = await _genreService.AnyAsync(g => g.Id == genreId);
        //        if (!doesExist)
        //        {
        //            throw new BusinessException($"Genre with ID {genreId} does not exist.");
        //        }
        //    }
        //}

       
        public async Task ActorsShouldExistWhenInsert(IEnumerable<Guid> actorIds)  //IEnumerable,IList,ICollection ??
        {
            // NOT => Veri Yapıları: IEnumerable<Guid> kullanımı veri üzerinde yineleme yapmak için yeterli ve verimli.Eğer koleksiyon üzerinde ek işlemler (sıralama, indeks erişimi gibi) gerekiyorsa IList veya ICollection kullanılabilir.

            foreach (var actorId in actorIds)
            {
                bool doesExist = await _actorService.AnyAsync(a => a.Id == actorId);
                if (!doesExist)
                    throw new BusinessException(FilmBusinessMessages.ActorsNotValid);
            }
        }

        public async Task DirectorShouldExistWhenInsert(Guid directorId)
        {
            bool doesExist = await _directorService.AnyAsync(d => d.Id == directorId);
            if (!doesExist)
                throw new BusinessException(FilmBusinessMessages.DirectorNotValid);
        }
    }
}
