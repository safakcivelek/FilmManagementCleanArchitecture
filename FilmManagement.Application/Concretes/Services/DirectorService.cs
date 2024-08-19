using DirectorManagement.Application.Features.Directors.Constants;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DirectorManagement.Application.Concretes.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }    

        public async Task<ApiResponse<Director>?> GetAsync(Expression<Func<Director, bool>> predicate, Func<IQueryable<Director>, IIncludableQueryable<Director, object>>? include = null, bool enableTracking = true, bool withDeleted = false)
        {
            Director? director = await _directorRepository.GetAsync(predicate, include, enableTracking, withDeleted);
            if (director == null)
                //Get metodu için, kaynak bulunamadığında 404 status kodu ile birlikte anlamlı bir hata mesajı döndürmek uygun bir yaklaşımdır. Bu durum, özellikle belirli bir kaynağı ararken (örneğin, belirli bir ID'ye sahip bir director) yaygındır ve kullanıcıya doğru bilgi vermek açısından önemlidir.
                return new ApiResponse<Director>(director, DirectorServiceMessages.DirectorNotFound, 404);
            return new ApiResponse<Director>(director, DirectorServiceMessages.DirectorRetrievedSuccessfully);
        }

        public async Task<ApiPagedResponse<Director>> GetListAsync(Expression<Func<Director, bool>>? predicate = null, Func<IQueryable<Director>, IIncludableQueryable<Director, object>>? include = null, bool enableTracking = true, bool withDeleted = false)
        {
            IList<Director> directorList = await _directorRepository.GetListAsync(predicate, include, enableTracking, withDeleted);
            if (directorList.Count == 0)
                //Bu metot içinde hiç director bulunamaması durumu, iş akışının normal bir parçası olarak ele alınabilir. Bu durumda, 404 status kodu yerine, 200 status kodu ile "Hiç director bulunamadı" mesajı döndürmek daha uygun olur. 404 status kodu, genellikle kaynak bulunamadığında (örneğin, belirli bir ID'ye sahip bir director bulunamadığında) kullanılır.
                return new ApiPagedResponse<Director>(directorList, DirectorServiceMessages.NoDirectorsFound, 404); // Düzenle 404/200 ?
            return new ApiPagedResponse<Director>(directorList, DirectorServiceMessages.DirectorsListedSuccessfully);
        }

        public async Task<bool> AnyAsync(Expression<Func<Director, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false)
        {
            bool directorExists = await _directorRepository.AnyAsync(predicate, enableTracking, withDeleted);
            return directorExists;
        }

        public async Task<ApiResponse<Director>> AddAsync(Director director)
        {
            Director addedDirector = await _directorRepository.AddAsync(director);
            return new ApiResponse<Director>(addedDirector, DirectorServiceMessages.DirectorAddedSuccessfully);
        }

        public async Task<ApiResponse<Director>> UpdateAsync(Director director)
        {
            Director updatedDirector = await _directorRepository.UpdateAsync(director);
            return new ApiResponse<Director>(updatedDirector, DirectorServiceMessages.DirectorUpdatedSuccessfully);
        }
        public async Task<ApiResponse<Director>> DeleteAsync(Director director)
        {
            Director deletedDirector = await _directorRepository.DeleteAsync(director);
            return new ApiResponse<Director>(deletedDirector, DirectorServiceMessages.DirectorDeletedSuccessfully);
        }

        public async Task<ApiPagedResponse<Director>> AddRangeAsync(IList<Director> directors)
        {
            IList<Director> addedDirectors = await _directorRepository.AddRangeAsync(directors);
            return new ApiPagedResponse<Director>(addedDirectors, DirectorServiceMessages.DirectorsAddedSuccessfully);
        }

        public async Task<ApiPagedResponse<Director>> UpdateRangeAsync(IList<Director> directors)
        {
            IList<Director> updatedDirectors = await _directorRepository.UpdateRangeAsync(directors);
            return new ApiPagedResponse<Director>(updatedDirectors, DirectorServiceMessages.DirectorsUpdatedSuccessfully);
        }

        public async Task<ApiPagedResponse<Director>> DeleteRangeAsync(IList<Director> directors)
        {
            IList<Director> deletedDirectors = await _directorRepository.DeleteRangeAsync(directors);
            return new ApiPagedResponse<Director>(deletedDirectors, DirectorServiceMessages.DirectorsDeletedSuccessfully);
        }      
    }
}
