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

        Task<ApiListResponse<Film>> GetListAsync(
        Expression<Func<Film, bool>>? predicate = null,
        Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false
        );

        Task<ApiResponse<Film>> AddAsync(Film film);

        Task<ApiResponse<Film>> UpdateAsync(Film film);

        Task<ApiResponse<Film>> DeleteAsync(Film film);

        Task<ApiListResponse<Film>> AddRangeAsync(IList<Film> films);
        Task<ApiListResponse<Film>> UpdateRangeAsync(IList<Film> films);
        Task<ApiListResponse<Film>> DeleteRangeAsync(IList<Film> films);
    }
}
