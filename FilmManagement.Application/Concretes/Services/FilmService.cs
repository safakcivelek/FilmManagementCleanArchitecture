using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<ApiResponse<Film>?> GetAsync(Expression<Func<Film, bool>> predicate, Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null, bool enableTracking = true)
        {
            Film? film = await _filmRepository.GetAsync(predicate, include, enableTracking);
            return new ApiResponse<Film>(film, "Film başarıyla getirildi.");
        }

        public async Task<ApiListResponse<Film>> GetListAsync(Expression<Func<Film, bool>>? predicate = null, Func<IQueryable<Film>, IIncludableQueryable<Film, object>>? include = null, bool enableTracking = true)
        {
            IList<Film> filmList = await _filmRepository.GetListAsync(predicate, include, enableTracking);
            return new ApiListResponse<Film>(filmList, "Filmler başarıyla listelendi.");
        }

        public async Task<ApiResponse<Film>> AddAsync(Film film)
        {
            Film addedFilm = await _filmRepository.AddAsync(film);
            return new ApiResponse<Film>(addedFilm, "Film başarıyla oluşturuldu.");
        }

        public async Task<ApiResponse<Film>> UpdateAsync(Film film)
        {
            Film updatedFilm = await _filmRepository.UpdateAsync(film);
            return new ApiResponse<Film>(updatedFilm, "Film başarıyla güncellendi.");
        }
        public async Task<ApiResponse<Film>> DeleteAsync(Film film)
        {
            Film deletedFilm = await _filmRepository.DeleteAsync(film);
            return new ApiResponse<Film>(deletedFilm,"Film başarıyla silindi.");
        }

        public async Task<ApiListResponse<Film>> AddRangeAsync(IList<Film> films)
        {
            IList<Film> addedFilms =await _filmRepository.AddRangeAsync(films);
            return new ApiListResponse<Film>(addedFilms, "Filmler başarıyla eklendi.");
        }

        public async Task<ApiListResponse<Film>> UpdateRangeAsync(IList<Film> films)
        {
            IList<Film> updatedFilms = await _filmRepository.UpdateRangeAsync(films);
            return new ApiListResponse<Film>(updatedFilms, "Filmler başarıyla güncellendi.");
        }

        public async Task<ApiListResponse<Film>> DeleteRangeAsync(IList<Film> films)
        {
            IList<Film> deletedFilms = await _filmRepository.DeleteRangeAsync(films);
            return new ApiListResponse<Film>(deletedFilms, "Filmler başarıyla silindi.");
        }
    }
}
