using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<Actor?> GetAsync(Expression<Func<Actor, bool>> predicate, Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null, bool enableTracking = true)
        {
            Actor? actor = await _actorRepository.GetAsync(predicate, include, enableTracking);
            return actor;
        }

        public async Task<IList<Actor>> GetListAsync(Expression<Func<Actor, bool>>? predicate = null, Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null, bool enableTracking = true)
        {
            IList<Actor> actorList= await _actorRepository.GetListAsync(predicate, include, enableTracking);
            return actorList;
        }

        public async Task<Actor> AddAsync(Actor actor)
        {
            Actor addedActor=await _actorRepository.AddAsync(actor);
            return addedActor;
        }

        public async Task<Actor> UpdateAsync(Actor actor)
        {
            Actor updatedActor = await _actorRepository.UpdateAsync(actor);
            return updatedActor;
        }
        public async Task<Actor> DeleteAsync(Actor actor)
        {
            Actor deletedActor =await _actorRepository.DeleteAsync(actor);
            return deletedActor;
        }
    }
}
