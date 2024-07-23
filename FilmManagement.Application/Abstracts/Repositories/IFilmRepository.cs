using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Abstracts.Repositories
{
    public interface IFilmRepository : IBaseRepository<Film, Guid>
    {
    }
}
