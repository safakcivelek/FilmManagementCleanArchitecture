using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Abstracts.Repositories
{
    public interface IGenreRepository : IBaseRepository<Genre, Guid>
    {
    }
}
