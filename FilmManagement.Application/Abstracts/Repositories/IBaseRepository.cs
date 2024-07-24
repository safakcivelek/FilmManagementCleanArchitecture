using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Repositories
{
    public interface IBaseRepository<TEntity,TEntityId> 
        where TEntity : BaseEntity<TEntityId>
    {
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool enableTracking = true);

        Task<IList<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool enableTracking = true);

        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity, bool forceDelete = false);

        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);
        Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities);
        Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool forceDelete = false);
    }
}
