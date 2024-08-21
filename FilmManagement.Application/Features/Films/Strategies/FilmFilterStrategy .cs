using FilmManagement.Application.Common.Dynamic;
using FilmManagement.Application.Common.Strategies;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace FilmManagement.Application.Features.Films.Strategies
{
    public class FilmFilterStrategy : IFilterStrategy<Film>
    {
        public IQueryable<Film> ApplyFilter(IQueryable<Film> query, DynamicQuery dynamicQuery)
        {
            if (dynamicQuery.Filter != null)
            {
                query = ProcessFilmFilter(query, dynamicQuery.Filter);
            }

            return query;
        }

        private IQueryable<Film> ProcessFilmFilter(IQueryable<Film> query, Filter filter)
        {
            if (filter.Field == "GenreName")
            {
                query = query.Include(f => f.FilmGenres)
                             .ThenInclude(fg => fg.Genre)
                             .Where(f => f.FilmGenres.Any(fg => fg.Genre.Name == filter.Value));
            }
            else if (filter.Field == "DirectorName")
            {
                query = query.Include(f => f.Director)
                             .Where(f => f.Director.FirstName == filter.Value);
            }
            else if (filter.Field == "ActorName")
            {
                query = query.Include(f => f.FilmActors)
                             .ThenInclude(fa => fa.Actor)
                             .Where(f => f.FilmActors.Any(fa => fa.Actor.FirstName.Contains(filter.Value)));
            }
            return query;
        }
    }
}
