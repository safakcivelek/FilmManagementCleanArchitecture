using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Dynamic;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilmManagement.Persistence.Repositories
{
    public class FilmRepository : EfBaseRepository<Film, Guid, BaseDbContext>, IFilmRepository
    {
        private readonly BaseDbContext _context;
        public FilmRepository(BaseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Film>> GetFilmsByDynamicAsync(
                    DynamicQuery dynamicQuery,
                    Expression<Func<Film, bool>>? predicate = null,
                    Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
                    bool enableTracking = true,
                    bool withDeleted = false,
                    int? skip = 0,
                    int? take = 10)
        {
            IQueryable<Film> queryable = _context.Films.AsQueryable().ToDynamic(dynamicQuery);

            if (include != null)
                queryable = include(queryable);         

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (withDeleted)  // Global filtreleri devre dışı bırak(HasQueryFilter)  
                queryable = queryable.IgnoreQueryFilters();       
            
            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (skip.HasValue)
                queryable = queryable.Skip(skip.Value);
            if (take.HasValue)
                queryable = queryable.Take(take.Value);

            return await queryable.ToListAsync();
        }
    }

}
