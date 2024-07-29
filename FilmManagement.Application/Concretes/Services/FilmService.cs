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
                return new ApiResponse<Film>(film,FilmServiceMessages.FilmNotFound,404);
            return new ApiResponse<Film>(film,FilmServiceMessages.FilmRetrievedSuccessfully);
        }

        public async Task<ApiListResponse<Film>> GetListAsync(Expression<Func<Film, bool>>? predicate = null, Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null, bool enableTracking = true, bool withDeleted = false)
        {
            IList<Film> filmList = await _filmRepository.GetListAsync(predicate, include, enableTracking, withDeleted);
            if (filmList.Count == 0)
                return new ApiListResponse<Film>(filmList, FilmServiceMessages.NoFilmsFound, 404);
            return new ApiListResponse<Film>(filmList, FilmServiceMessages.FilmsListedSuccessfully);
        }

        public async Task<bool> AnyAsync(Expression<Func<Film, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false)
        {
            bool filmExists = await _filmRepository.AnyAsync(predicate, enableTracking, withDeleted);
            return filmExists;
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

        public async Task<ApiListResponse<Film>> AddRangeAsync(IList<Film> films)
        {
            IList<Film> addedFilms = await _filmRepository.AddRangeAsync(films);
            return new ApiListResponse<Film>(addedFilms, FilmServiceMessages.FilmsAddedSuccessfully);
        }

        public async Task<ApiListResponse<Film>> UpdateRangeAsync(IList<Film> films)
        {
            IList<Film> updatedFilms = await _filmRepository.UpdateRangeAsync(films);
            return new ApiListResponse<Film>(updatedFilms, FilmServiceMessages.FilmsUpdatedSuccessfully);
        }

        public async Task<ApiListResponse<Film>> DeleteRangeAsync(IList<Film> films)
        {
            IList<Film> deletedFilms = await _filmRepository.DeleteRangeAsync(films);
            return new ApiListResponse<Film>(deletedFilms, FilmServiceMessages.FilmsDeletedSuccessfully);
        }
    }
}
