using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class DirectorRepository : EfBaseRepository<Director, Guid, BaseDbContext>, IDirectorRepository
    {
        public DirectorRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
