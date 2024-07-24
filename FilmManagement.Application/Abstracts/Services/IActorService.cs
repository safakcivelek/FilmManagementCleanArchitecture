using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IActorService
    {
        Task<Actor?> GetAsync(
        Expression<Func<Actor, bool>> predicate,
        Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null,
        bool enableTracking = true);

        Task<IList<Actor>> GetListAsync(
        Expression<Func<Actor, bool>>? predicate = null,
        Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null,
        bool enableTracking = true);

        Task<Actor> AddAsync(Actor actor);

        Task<Actor> UpdateAsync(Actor actor);

        Task<Actor> DeleteAsync(Actor actor);
    }
}
