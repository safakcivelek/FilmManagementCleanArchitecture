using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Dynamic;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace FilmManagement.Persistence.Repositories
{
    public class FilmRepository : EfBaseRepository<Film, Guid, BaseDbContext>, IFilmRepository
    {
        private readonly BaseDbContext _context;
        public FilmRepository(BaseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Film>> GetFilmsByDynamicAsync(DynamicQuery dynamicQuery,
                    Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
                    bool enableTracking = true,
                    bool withDeleted = false,
                    int? skip = 0,
                    int? take = 10)
        {
            IQueryable<Film> queryable = _context.Films.AsQueryable().ToDynamic(dynamicQuery);

            queryable = queryable
           .Include(f => f.FilmGenres)
               .ThenInclude(fg => fg.Genre)
           .Include(f => f.Director)
           .Include(f => f.FilmActors)
               .ThenInclude(fa => fa.Actor);

            if (include != null)
                queryable = include(queryable);
           

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (!withDeleted)
                queryable = queryable.Where(f => f.IsActive);
            else
                queryable = queryable.IgnoreQueryFilters();

            if (skip.HasValue)
                queryable = queryable.Skip(skip.Value);
            if (take.HasValue)
                queryable = queryable.Take(take.Value);

            return await queryable.ToListAsync();
        }
    }

}
