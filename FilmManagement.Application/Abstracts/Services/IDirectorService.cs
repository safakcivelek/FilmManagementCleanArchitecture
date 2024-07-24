using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IDirectorService
    {
        Task<Director?> GetAsync(
        Expression<Func<Director, bool>> predicate,
        Func<IQueryable<Director>, IIncludableQueryable<Director, object>>? include = null,
        bool enableTracking = true);

        Task<IList<Director>> GetListAsync(
        Expression<Func<Director, bool>>? predicate = null,
        Func<IQueryable<Director>, IIncludableQueryable<Director, object>>? include = null,
        bool enableTracking = true);

        Task<Director> AddAsync(Director director);

        Task<Director> UpdateAsync(Director director);

        Task<Director> DeleteAsync(Director director);
    }
}
