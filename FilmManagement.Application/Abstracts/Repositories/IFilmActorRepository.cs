using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Abstracts.Repositories
{
    public interface IFilmActorRepository : IBaseRepository<FilmActor, Guid>
    {
    }
}
