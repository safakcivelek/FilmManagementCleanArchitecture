using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes.Services
{
    public class FilmActorService : IFilmActorService
    {
        private readonly IFilmActorRepository _filmActorRepository;

        public FilmActorService(IFilmActorRepository filmFilmActorRepository)
        {
            _filmActorRepository = filmFilmActorRepository;
        }

        public async Task<FilmActor?> GetAsync(Expression<Func<FilmActor, bool>> predicate, Func<IQueryable<FilmActor>, IIncludableQueryable<FilmActor, object>>? include = null, bool enableTracking = true)
        {
            FilmActor? filmActor = await _filmActorRepository.GetAsync(predicate, include, enableTracking);
            return filmActor;
        }

        public async Task<IList<FilmActor>> GetListAsync(Expression<Func<FilmActor, bool>>? predicate = null, Func<IQueryable<FilmActor>, IIncludableQueryable<FilmActor, object>>? include = null, bool enableTracking = true)
        {
            IList<FilmActor> filmActorList = await _filmActorRepository.GetListAsync(predicate, include, enableTracking);
            return filmActorList;
        }

        public async Task<FilmActor> AddAsync(FilmActor filmActor)
        {
            FilmActor addedFilmActor = await _filmActorRepository.AddAsync(filmActor);
            return addedFilmActor;
        }

        public async Task<FilmActor> UpdateAsync(FilmActor filmActor)
        {
            FilmActor updatedFilmActor = await _filmActorRepository.UpdateAsync(filmActor);
            return updatedFilmActor;
        }
        public async Task<FilmActor> DeleteAsync(FilmActor filmActor)
        {
            FilmActor deletedFilmActor = await _filmActorRepository.DeleteAsync(filmActor);
            return deletedFilmActor;
        }
    }
}
