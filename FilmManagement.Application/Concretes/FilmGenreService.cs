using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes
{
    public class FilmGenreService : IFilmGenreService
    {
        private readonly IFilmGenreRepository _filmGenreRepository;

        public FilmGenreService(IFilmGenreRepository filmGenreRepository)
        {
            _filmGenreRepository = filmGenreRepository;
        }

        public async Task<FilmGenre?> GetAsync(Expression<Func<FilmGenre, bool>> predicate, Func<IQueryable<FilmGenre>, IIncludableQueryable<FilmGenre, object>>? include = null, bool enableTracking = true)
        {
            FilmGenre? filmGenre = await _filmGenreRepository.GetAsync(predicate, include, enableTracking);
            return filmGenre;
        }

        public async Task<IList<FilmGenre>> GetListAsync(Expression<Func<FilmGenre, bool>>? predicate = null, Func<IQueryable<FilmGenre>, IIncludableQueryable<FilmGenre, object>>? include = null, bool enableTracking = true)
        {
            IList<FilmGenre> filmGenreList = await _filmGenreRepository.GetListAsync(predicate, include, enableTracking);
            return filmGenreList;
        }

        public async Task<FilmGenre> AddAsync(FilmGenre filmGenre)
        {
            FilmGenre addedFilmGenre = await _filmGenreRepository.AddAsync(filmGenre);
            return addedFilmGenre;
        }

        public async Task<FilmGenre> UpdateAsync(FilmGenre filmGenre)
        {
            FilmGenre updatedFilmGenre = await _filmGenreRepository.UpdateAsync(filmGenre);
            return updatedFilmGenre;
        }
        public async Task<FilmGenre> DeleteAsync(FilmGenre filmGenre)
        {
            FilmGenre deletedFilmGenre = await _filmGenreRepository.DeleteAsync(filmGenre);
            return deletedFilmGenre;
        }
    }
}
