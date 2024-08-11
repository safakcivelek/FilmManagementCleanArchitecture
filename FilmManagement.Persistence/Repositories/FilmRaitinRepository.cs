using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class FilmRatingRepository : EfBaseRepository<FilmRating, Guid, BaseDbContext>, IFilmRatingRepository
    {
        public FilmRatingRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
