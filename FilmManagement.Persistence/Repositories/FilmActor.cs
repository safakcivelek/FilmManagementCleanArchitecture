
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class FilmActor : EfBaseRepository<FilmActor, Guid, BaseDbContext>, IFilmActorRepository
    {
        public FilmActor(BaseDbContext context) : base(context)
        {
        }
    }
}
