
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class FilmActorRepository : EfBaseRepository<FilmActor, Guid, BaseDbContext>, IFilmActorRepository
    {
        public FilmActorRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
