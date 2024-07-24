using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface ICustomerFavoriteGenreService
    {
        Task<CustomerFavoriteGenre?> GetAsync(
        Expression<Func<CustomerFavoriteGenre, bool>> predicate,
        Func<IQueryable<CustomerFavoriteGenre>, IIncludableQueryable<CustomerFavoriteGenre, object>>? include = null,
        bool enableTracking = true);

        Task<IList<CustomerFavoriteGenre>> GetListAsync(
        Expression<Func<CustomerFavoriteGenre, bool>>? predicate = null,
        Func<IQueryable<CustomerFavoriteGenre>, IIncludableQueryable<CustomerFavoriteGenre, object>>? include = null,
        bool enableTracking = true);

        Task<CustomerFavoriteGenre> AddAsync(CustomerFavoriteGenre  customerFavoriteGenre);

        Task<CustomerFavoriteGenre> UpdateAsync(CustomerFavoriteGenre customerFavoriteGenre);

        Task<CustomerFavoriteGenre> DeleteAsync(CustomerFavoriteGenre customerFavoriteGenre);
    }
}
