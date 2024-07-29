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
            bool enableTracking = true,
            bool withDeleted = false
            );

        Task<IList<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool enableTracking = true,
            bool withDeleted = false
            );

        Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool enableTracking = true,
            bool withDeleted = false
            );

        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity, bool forceDelete = false);

        Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entities);
        Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities);
        Task<IList<TEntity>> DeleteRangeAsync(IList<TEntity> entities, bool forceDelete = false);
    }
}
