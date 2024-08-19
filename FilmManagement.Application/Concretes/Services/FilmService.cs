using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Films.Constants;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<ApiResponse<Film>?> GetAsync(Expression<Func<Film, bool>> predicate, Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null, bool enableTracking = true, bool withDeleted = false)
        {
            Film? film = await _filmRepository.GetAsync(predicate, include, enableTracking, withDeleted);
            if (film == null)
                //Get metodu için, kaynak bulunamadığında 404 status kodu ile birlikte anlamlı bir hata mesajı döndürmek uygun bir yaklaşımdır. Bu durum, özellikle belirli bir kaynağı ararken (örneğin, belirli bir ID'ye sahip bir film) yaygındır ve kullanıcıya doğru bilgi vermek açısından önemlidir.
                return new ApiResponse<Film>(film, FilmServiceMessages.FilmNotFound, 404);
            return new ApiResponse<Film>(film, FilmServiceMessages.FilmRetrievedSuccessfully);
        }

        public async Task<ApiPagedResponse<Film>> GetListAsync(
            Expression<Func<Film, bool>>? predicate = null, Func<IQueryable<Film>, IIncludableQueryable<Film, object>>?
            include = null, bool enableTracking = true, bool withDeleted = false, int? skip = 0, int? take = 10)
        {
            IList<Film> filmList = await _filmRepository.GetListAsync(predicate, include, enableTracking, withDeleted,skip,take);
            if (filmList.Count == 0)
                //Bu metot içinde hiç film bulunamaması durumu, iş akışının normal bir parçası olarak ele alınabilir. Bu durumda, 404 status kodu yerine, 200 status kodu ile "Hiç film bulunamadı" mesajı döndürmek daha uygun olur. 404 status kodu, genellikle kaynak bulunamadığında (örneğin, belirli bir ID'ye sahip bir film bulunamadığında) kullanılır.
                return new ApiPagedResponse<Film>(filmList, FilmServiceMessages.NoFilmsFound, 404); // Düzenle 404/200 ?
            return new ApiPagedResponse<Film>(filmList, FilmServiceMessages.FilmsListedSuccessfully);
        }

        public async Task<bool> AnyAsync(Expression<Func<Film, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false)
        {
            bool filmExists = await _filmRepository.AnyAsync(predicate, enableTracking, withDeleted);
            return filmExists;
        }

        public async Task<int> CountAsync(Expression<Func<Film, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false)
        {
            int filmCount = await _filmRepository.CountAsync(predicate, enableTracking, withDeleted);
            return filmCount;
        }

        public async Task<ApiResponse<Film>> AddAsync(Film film)
        {
            Film addedFilm = await _filmRepository.AddAsync(film);
            return new ApiResponse<Film>(addedFilm, FilmServiceMessages.FilmAddedSuccessfully);
        }

        public async Task<ApiResponse<Film>> UpdateAsync(Film film)
        {
            Film updatedFilm = await _filmRepository.UpdateAsync(film);
            return new ApiResponse<Film>(updatedFilm, FilmServiceMessages.FilmUpdatedSuccessfully);
        }
        public async Task<ApiResponse<Film>> DeleteAsync(Film film)
        {
            Film deletedFilm = await _filmRepository.DeleteAsync(film);
            return new ApiResponse<Film>(deletedFilm, FilmServiceMessages.FilmDeletedSuccessfully);
        }

        public async Task<ApiPagedResponse<Film>> AddRangeAsync(IList<Film> films)
        {
            IList<Film> addedFilms = await _filmRepository.AddRangeAsync(films);
            return new ApiPagedResponse<Film>(addedFilms, FilmServiceMessages.FilmsAddedSuccessfully);
        }

        public async Task<ApiPagedResponse<Film>> UpdateRangeAsync(IList<Film> films)
        {
            IList<Film> updatedFilms = await _filmRepository.UpdateRangeAsync(films);
            return new ApiPagedResponse<Film>(updatedFilms, FilmServiceMessages.FilmsUpdatedSuccessfully);
        }

        public async Task<ApiPagedResponse<Film>> DeleteRangeAsync(IList<Film> films)
        {
            IList<Film> deletedFilms = await _filmRepository.DeleteRangeAsync(films);
            return new ApiPagedResponse<Film>(deletedFilms, FilmServiceMessages.FilmsDeletedSuccessfully);
        }
    }
}
