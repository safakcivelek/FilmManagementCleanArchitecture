using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IFilmGenreService
    {
        Task<FilmGenre?> GetAsync(
        Expression<Func<FilmGenre, bool>> predicate,
        Func<IQueryable<FilmGenre>, IIncludableQueryable<FilmGenre, object>>? include = null,
        bool enableTracking = true);

        Task<IList<FilmGenre>> GetListAsync(
        Expression<Func<FilmGenre, bool>>? predicate = null,
        Func<IQueryable<FilmGenre>, IIncludableQueryable<FilmGenre, object>>? include = null,
        bool enableTracking = true);

        Task<FilmGenre> AddAsync(FilmGenre filmGenre);

        Task<FilmGenre> UpdateAsync(FilmGenre filmGenre);

        Task<FilmGenre> DeleteAsync(FilmGenre filmGenre);
    }
}
