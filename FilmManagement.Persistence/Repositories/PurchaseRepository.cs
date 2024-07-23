using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Domain.Entities;
using FilmManagement.Persistence.Contexts;

namespace FilmManagement.Persistence.Repositories
{
    public class PurchaseRepository : EfBaseRepository<Purchase, Guid, BaseDbContext>, IPurchaseRepository
    {
        public PurchaseRepository(BaseDbContext context) : base(context)
        {
        }       
    }
}
