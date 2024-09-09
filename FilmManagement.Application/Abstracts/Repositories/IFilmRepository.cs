using FilmManagement.Application.Common.Dynamic;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Repositories
{
    public interface IFilmRepository : IBaseRepository<Film, Guid>
    {
        Task<IList<Film>> GetFilmsByDynamicAsync(DynamicQuery dynamic,
        Expression<Func<Film, bool>>? predicate = null,
        Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false,
        int? skip = 0,
        int? take = 10);
    }
}
