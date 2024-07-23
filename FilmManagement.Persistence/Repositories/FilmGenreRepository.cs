
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class FilmGenreRepository : EfBaseRepository<FilmGenre, Guid, BaseDbContext>, IFilmGenreRepository
    {
        public FilmGenreRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
