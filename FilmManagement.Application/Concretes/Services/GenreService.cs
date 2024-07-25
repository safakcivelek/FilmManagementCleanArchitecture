using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre?> GetAsync(Expression<Func<Genre, bool>> predicate, Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null, bool enableTracking = true)
        {
            Genre? genre = await _genreRepository.GetAsync(predicate, include, enableTracking);
            return genre;
        }

        public async Task<IList<Genre>> GetListAsync(Expression<Func<Genre, bool>>? predicate = null, Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null, bool enableTracking = true)
        {
            IList<Genre> genreList = await _genreRepository.GetListAsync(predicate, include, enableTracking);
            return genreList;
        }

        public async Task<Genre> AddAsync(Genre genre)
        {
            Genre addedGenre = await _genreRepository.AddAsync(genre);
            return addedGenre;
        }

        public async Task<Genre> UpdateAsync(Genre genre)
        {
            Genre updatedGenre = await _genreRepository.UpdateAsync(genre);
            return updatedGenre;
        }
        public async Task<Genre> DeleteAsync(Genre genre)
        {
            Genre deletedGenre = await _genreRepository.DeleteAsync(genre);
            return deletedGenre;
        }
    }
}
