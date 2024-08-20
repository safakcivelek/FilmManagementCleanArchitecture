using FilmManagement.Application.Common.Dynamic;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IFilmService
    {
        Task<ApiResponse<Film?>> GetAsync(
        Expression<Func<Film, bool>> predicate,
        Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false
        );

        Task<ApiPagedResponse<Film>> GetListAsync(
        Expression<Func<Film, bool>>? predicate = null,
        Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false,
        int? skip = 0,
        int? take = 10
        );
       
        Task<ApiPagedResponse<Film>> GetListByDynamicAsync(
            DynamicQuery dynamicQuery,
            Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
            bool enableTracking = true,
            bool withDeleted = false,
            int? skip = 0,
            int? take = 10
        );

        Task<bool> AnyAsync(
        Expression<Func<Film, bool>>? predicate = null,       
        bool enableTracking = true,
        bool withDeleted = false
        );

        Task<int> CountAsync(
            Expression<Func<Film, bool>>? predicate = null,
            bool enableTracking = true,
            bool withDeleted = false
            );

        Task<ApiResponse<Film>> AddAsync(Film film);

        Task<ApiResponse<Film>> UpdateAsync(Film film);

        Task<ApiResponse<Film>> DeleteAsync(Film film);

        Task<ApiPagedResponse<Film>> AddRangeAsync(IList<Film> films);
        Task<ApiPagedResponse<Film>> UpdateRangeAsync(IList<Film> films);
        Task<ApiPagedResponse<Film>> DeleteRangeAsync(IList<Film> films);
    }
}
