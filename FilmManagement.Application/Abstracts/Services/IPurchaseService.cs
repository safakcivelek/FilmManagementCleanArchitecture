using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IPurchaseService
    {
        Task<Purchase?> GetAsync(
        Expression<Func<Purchase, bool>> predicate,
        Func<IQueryable<Purchase>, IIncludableQueryable<Purchase, object>>? include = null,
        bool enableTracking = true);

        Task<IList<Purchase>> GetListAsync(
        Expression<Func<Purchase, bool>>? predicate = null,
        Func<IQueryable<Purchase>, IIncludableQueryable<Purchase, object>>? include = null,
        bool enableTracking = true);

        Task<Purchase> AddAsync(Purchase purchase);

        Task<Purchase> UpdateAsync(Purchase purchase);

        Task<Purchase> DeleteAsync(Purchase purchase);
    }
}
