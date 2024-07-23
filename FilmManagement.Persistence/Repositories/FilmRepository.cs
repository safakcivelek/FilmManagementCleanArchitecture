using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class FilmRepository : EfBaseRepository<Film, Guid, BaseDbContext>, IFilmRepository
    {
        public FilmRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
