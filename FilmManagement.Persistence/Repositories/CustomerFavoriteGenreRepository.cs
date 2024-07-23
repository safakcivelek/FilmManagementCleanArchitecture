using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class CustomerFavoriteGenreRepository : EfBaseRepository<CustomerFavoriteGenre, Guid, BaseDbContext>,ICustomerFavoriteGenreRepository
    {
        public CustomerFavoriteGenreRepository(BaseDbContext context) : base(context)
        {
        }
    }


}
