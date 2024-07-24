using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface ICustomerService
    {
        Task<Customer?> GetAsync(
        Expression<Func<Customer, bool>> predicate,
        Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null,
        bool enableTracking = true);

        Task<IList<Customer>> GetListAsync(
        Expression<Func<Customer, bool>>? predicate = null,
        Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null,
        bool enableTracking = true);

        Task<Customer> AddAsync(Customer customer);

        Task<Customer> UpdateAsync(Customer customer);

        Task<Customer> DeleteAsync(Customer customer);
    }
}
