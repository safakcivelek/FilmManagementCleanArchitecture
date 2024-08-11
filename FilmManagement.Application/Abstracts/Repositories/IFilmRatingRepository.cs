using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Abstracts.Repositories
{
    public interface IFilmRatingRepository : IBaseRepository<FilmRating, Guid>
    {
    }
}
