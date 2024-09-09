using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IFilmActorService
    {
        Task<FilmActor?> GetAsync(
        Expression<Func<FilmActor, bool>> predicate,
        Func<IQueryable<FilmActor>, IIncludableQueryable<FilmActor, object>>? include = null,
        bool enableTracking = true);

        Task<IList<FilmActor>> GetListAsync(
        Expression<Func<FilmActor, bool>>? predicate = null,
        Func<IQueryable<FilmActor>, IOrderedQueryable<FilmActor>>? orderBy = null,
        Func<IQueryable<FilmActor>, IIncludableQueryable<FilmActor, object>>? include = null,
        bool enableTracking = true);

        Task<FilmActor> AddAsync(FilmActor filmActor);

        Task<FilmActor> UpdateAsync(FilmActor filmActor);

        Task<FilmActor> DeleteAsync(FilmActor filmActor);
    }
}
