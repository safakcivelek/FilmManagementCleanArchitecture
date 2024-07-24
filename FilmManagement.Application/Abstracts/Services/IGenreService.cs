using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IGenreService
    {
        Task<Genre?> GetAsync(
        Expression<Func<Genre, bool>> predicate,
        Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null,
        bool enableTracking = true);

        Task<IList<Genre>> GetListAsync(
        Expression<Func<Genre, bool>>? predicate = null,
        Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null,
        bool enableTracking = true);

        Task<Genre> AddAsync(Genre genre);

        Task<Genre> UpdateAsync(Genre genre);

        Task<Genre> DeleteAsync(Genre genre);
    }
}
