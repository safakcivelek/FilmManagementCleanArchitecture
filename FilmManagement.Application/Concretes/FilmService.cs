
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes
{
    public class FilmService :IFilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<Film?> GetAsync(Expression<Func<Film, bool>> predicate, Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null, bool enableTracking = true)
        {
            Film? film = await _filmRepository.GetAsync(predicate, include, enableTracking);
            return film;
        }

        public async Task<IList<Film>> GetListAsync(Expression<Func<Film, bool>>? predicate = null, Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null, bool enableTracking = true)
        {
            IList<Film> filmList = await _filmRepository.GetListAsync(predicate, include, enableTracking);
            return filmList;
        }

        public async Task<Film> AddAsync(Film film)
        {
            Film addedFilm = await _filmRepository.AddAsync(film);
            return addedFilm;
        }

        public async Task<Film> UpdateAsync(Film film)
        {
            Film updatedFilm = await _filmRepository.UpdateAsync(film);
            return updatedFilm;
        }
        public async Task<Film> DeleteAsync(Film film)
        {
            Film deletedFilm = await _filmRepository.DeleteAsync(film);
            return deletedFilm;
        }
    }
}
