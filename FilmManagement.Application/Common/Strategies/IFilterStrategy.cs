using FilmManagement.Application.Common.Dynamic;

namespace FilmManagement.Application.Common.Strategies
{
    public interface IFilterStrategy<TEntity>
    {
        IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> query, DynamicQuery dynamicQuery);
    }
}
