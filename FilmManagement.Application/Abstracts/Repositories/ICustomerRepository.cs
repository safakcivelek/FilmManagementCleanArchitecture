using FilmManagement.Domain.Entities;

namespace FilmManagement.Application.Abstracts.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer, Guid>
    {
    }
}
