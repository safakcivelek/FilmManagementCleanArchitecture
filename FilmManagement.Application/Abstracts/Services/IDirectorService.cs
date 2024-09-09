using FilmManagement.Application.Common.Responses;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IDirectorService
    {
        Task<ApiResponse<Director?>> GetAsync(
        Expression<Func<Director, bool>> predicate,
        Func<IQueryable<Director>, IIncludableQueryable<Director, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false
        );

        Task<ApiPagedResponse<Director>> GetListAsync(
        Expression<Func<Director, bool>>? predicate = null,
        Func<IQueryable<Director>, IOrderedQueryable<Director>>? orderBy = null,
        Func<IQueryable<Director>, IIncludableQueryable<Director, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false
        );

        Task<bool> AnyAsync(
        Expression<Func<Director, bool>>? predicate = null,
        bool enableTracking = true,
        bool withDeleted = false
        );

        Task<ApiResponse<Director>> AddAsync(Director director);

        Task<ApiResponse<Director>> UpdateAsync(Director director);

        Task<ApiResponse<Director>> DeleteAsync(Director director);

        Task<ApiPagedResponse<Director>> AddRangeAsync(IList<Director> directors);
        Task<ApiPagedResponse<Director>> UpdateRangeAsync(IList<Director> directors);
        Task<ApiPagedResponse<Director>> DeleteRangeAsync(IList<Director> directors);
    }
}
