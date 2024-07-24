using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IFilmService
    {
        Task<Film?> GetAsync(
        Expression<Func<Film, bool>> predicate,
        Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
        bool enableTracking = true);

        Task<IList<Film>> GetListAsync(
        Expression<Func<Film, bool>>? predicate = null,
        Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
        bool enableTracking = true);

        Task<Film> AddAsync(Film film);

        Task<Film> UpdateAsync(Film film);

        Task<Film> DeleteAsync(Film film);
    }
}
