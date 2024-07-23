using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class GenreRepository : EfBaseRepository<Genre, Guid, BaseDbContext>, IGenreRepository
    {
        public GenreRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
