using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class ActorRepository : EfBaseRepository<Actor, Guid, BaseDbContext>,IActorRepository
    {
        public ActorRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
