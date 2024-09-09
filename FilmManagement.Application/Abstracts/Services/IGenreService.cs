using FilmManagement.Application.Common.Responses;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Abstracts.Services
{
    public interface IGenreService
    {
        Task<ApiResponse<Genre?>> GetAsync(
        Expression<Func<Genre, bool>> predicate,
        Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false
        );

        Task<ApiPagedResponse<Genre>> GetListAsync(
        Expression<Func<Genre, bool>>? predicate = null,
        Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy = null,
        Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false);

        Task<bool> AnyAsync(
        Expression<Func<Genre, bool>>? predicate = null,
        bool enableTracking = true,
        bool withDeleted = false
        );
  
        Task<ApiResponse<Genre>> AddAsync(Genre genre);
        Task<ApiResponse<Genre>> UpdateAsync(Genre genre);
        Task<ApiResponse<Genre>> DeleteAsync(Genre genre);   
    }
}
