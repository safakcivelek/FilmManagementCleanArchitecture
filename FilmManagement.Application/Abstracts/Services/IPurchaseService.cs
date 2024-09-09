using FilmManagement.Application.Common.Responses;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IPurchaseService
    {
        Task<ApiResponse<Purchase?>> GetAsync(
        Expression<Func<Purchase, bool>> predicate,
        Func<IQueryable<Purchase>, IIncludableQueryable<Purchase, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false
        );

        Task<ApiPagedResponse<Purchase>> GetListAsync(
        Expression<Func<Purchase, bool>>? predicate = null,
        Func<IQueryable<Purchase>, IOrderedQueryable<Purchase>>? orderBy = null,
        Func<IQueryable<Purchase>, IIncludableQueryable<Purchase, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false,
        int? skip = 0,
        int? take = 10
        );

        Task<bool> AnyAsync(
        Expression<Func<Purchase, bool>>? predicate = null,
        bool enableTracking = true,
        bool withDeleted = false
        );

        Task<int> CountAsync(
            Expression<Func<Purchase, bool>>? predicate = null,
            bool enableTracking = true,
            bool withDeleted = false
            );

        Task<ApiResponse<Purchase>> AddAsync(Purchase purchase);
        Task<ApiResponse<Purchase>> UpdateAsync(Purchase purchase);
        Task<ApiResponse<Purchase>> DeleteAsync(Purchase purchase);
    }
}
