
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes
{
    public class DirectorService :IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<Director?> GetAsync(Expression<Func<Director, bool>> predicate, Func<IQueryable<Director>, IIncludableQueryable<Director, object>>? include = null, bool enableTracking = true)
        {
            Director? director = await _directorRepository.GetAsync(predicate, include, enableTracking);
            return director;
        }

        public async Task<IList<Director>> GetListAsync(Expression<Func<Director, bool>>? predicate = null, Func<IQueryable<Director>, IIncludableQueryable<Director, object>>? include = null, bool enableTracking = true)
        {
            IList<Director> directorList = await _directorRepository.GetListAsync(predicate, include, enableTracking);
            return directorList;
        }

        public async Task<Director> AddAsync(Director director)
        {
            Director addedDirector = await _directorRepository.AddAsync(director);
            return addedDirector;
        }

        public async Task<Director> UpdateAsync(Director director)
        {
            Director updatedDirector = await _directorRepository.UpdateAsync(director);
            return updatedDirector;
        }
        public async Task<Director> DeleteAsync(Director director)
        {
            Director deletedDirector = await _directorRepository.DeleteAsync(director);
            return deletedDirector;
        }
    }
}
