using FilmManagement.Application.Common.Dynamic;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace FilmManagement.Application.Abstracts.Repositories
{
    public interface IFilmRepository : IBaseRepository<Film, Guid>
    {
        Task<IList<Film>> GetFilmsByDynamicAsync(DynamicQuery dynamic,
        Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false,
        int? skip = 0,
        int? take = 10);
    }
}
