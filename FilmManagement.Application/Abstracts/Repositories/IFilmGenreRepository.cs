using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Abstracts.Repositories
{
    public interface IFilmGenreRepository : IBaseRepository<FilmGenre, Guid>
    {
    }
}
