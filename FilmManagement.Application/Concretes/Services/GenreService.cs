using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Constants;
using FilmManagement.Application.Features.Genres.Constants;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<ApiResponse<Genre>?> GetAsync(Expression<Func<Genre, bool>> predicate, Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null, bool enableTracking = true, bool withDeleted = false)
        {
            Genre? genre = await _genreRepository.GetAsync(predicate, include, enableTracking,withDeleted);
            if (genre == null)
                return new ApiResponse<Genre>(genre, GenreServiceMessages.NoGenresFound, 404);
            return new ApiResponse<Genre>(genre, GenreServiceMessages.GenreRetrievedSuccessfully);      
        }

        public async Task<ApiPagedResponse<Genre>> GetListAsync(
            Expression<Func<Genre, bool>>? predicate = null,
            Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy = null,
            Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include = null,
            bool enableTracking = true, bool withDeleted = false)
        {
            IList<Genre> genreList = await _genreRepository.GetListAsync(predicate,orderBy, include, enableTracking,withDeleted);
            if (genreList.Count == 0)
                return new ApiPagedResponse<Genre>(genreList, GenreServiceMessages.NoGenresFound, 404);  
            return new ApiPagedResponse<Genre>(genreList, GenreServiceMessages.GenresListedSuccessfully);
        }

        public async Task<bool> AnyAsync(Expression<Func<Genre, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false)
        {
            bool genreExists = await _genreRepository.AnyAsync(predicate, enableTracking, withDeleted);
            return genreExists;
        }

        public async Task<ApiResponse<Genre>> AddAsync(Genre genre)
        {
            Genre addedGenre = await _genreRepository.AddAsync(genre);
            return new ApiResponse<Genre>(addedGenre, GenreServiceMessages.GenreAddedSuccessfully);
        }

        public async Task<ApiResponse<Genre>> UpdateAsync(Genre genre)
        {
            Genre updatedGenre = await _genreRepository.UpdateAsync(genre);
            return new ApiResponse<Genre>(updatedGenre, GenreServiceMessages.GenreUpdatedSuccessfully);
        }

        public async Task<ApiResponse<Genre>> DeleteAsync(Genre genre)
        {
            Genre deletedGenre= await _genreRepository.DeleteAsync(genre);
            return new ApiResponse<Genre>(deletedGenre,GenreServiceMessages.GenreDeletedSuccessfully);
        }
    }
}
