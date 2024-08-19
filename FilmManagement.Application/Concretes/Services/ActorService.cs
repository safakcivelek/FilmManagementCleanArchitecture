using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Actors.Constants;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<ApiResponse<Actor>?> GetAsync(Expression<Func<Actor, bool>> predicate, Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null, bool enableTracking = true, bool withDeleted = false)
        {
            Actor? actor = await _actorRepository.GetAsync(predicate, include, enableTracking, withDeleted);
            if (actor == null)
                //Get metodu için, kaynak bulunamadığında 404 status kodu ile birlikte anlamlı bir hata mesajı döndürmek uygun bir yaklaşımdır. Bu durum, özellikle belirli bir kaynağı ararken (örneğin, belirli bir ID'ye sahip bir actor) yaygındır ve kullanıcıya doğru bilgi vermek açısından önemlidir.
                return new ApiResponse<Actor>(actor, ActorServiceMessages.ActorNotFound, 404);
            return new ApiResponse<Actor>(actor, ActorServiceMessages.ActorRetrievedSuccessfully);
        }

        public async Task<ApiPagedResponse<Actor>> GetListAsync(Expression<Func<Actor, bool>>? predicate = null, Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null, bool enableTracking = true, bool withDeleted = false)
        {
            IList<Actor> actorList = await _actorRepository.GetListAsync(predicate, include, enableTracking, withDeleted);
            if (actorList.Count == 0)
                //Bu metot içinde hiç actor bulunamaması durumu, iş akışının normal bir parçası olarak ele alınabilir. Bu durumda, 404 status kodu yerine, 200 status kodu ile "Hiç actor bulunamadı" mesajı döndürmek daha uygun olur. 404 status kodu, genellikle kaynak bulunamadığında (örneğin, belirli bir ID'ye sahip bir actor bulunamadığında) kullanılır.
                return new ApiPagedResponse<Actor>(actorList, ActorServiceMessages.NoActorsFound, 404); // Düzenle 404/200 ?
            return new ApiPagedResponse<Actor>(actorList, ActorServiceMessages.ActorsListedSuccessfully);
        }

        public async Task<bool> AnyAsync(Expression<Func<Actor, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false)
        {
            bool actorExists = await _actorRepository.AnyAsync(predicate, enableTracking, withDeleted);
            return actorExists;
        }

        public async Task<ApiResponse<Actor>> AddAsync(Actor actor)
        {
            Actor addedActor = await _actorRepository.AddAsync(actor);
            return new ApiResponse<Actor>(addedActor, ActorServiceMessages.ActorAddedSuccessfully);
        }

        public async Task<ApiResponse<Actor>> UpdateAsync(Actor actor)
        {
            Actor updatedActor = await _actorRepository.UpdateAsync(actor);
            return new ApiResponse<Actor>(updatedActor, ActorServiceMessages.ActorUpdatedSuccessfully);
        }
        public async Task<ApiResponse<Actor>> DeleteAsync(Actor actor)
        {
            Actor deletedActor = await _actorRepository.DeleteAsync(actor);
            return new ApiResponse<Actor>(deletedActor, ActorServiceMessages.ActorDeletedSuccessfully);
        }

        public async Task<ApiPagedResponse<Actor>> AddRangeAsync(IList<Actor> actors)
        {
            IList<Actor> addedActors = await _actorRepository.AddRangeAsync(actors);
            return new ApiPagedResponse<Actor>(addedActors, ActorServiceMessages.ActorsAddedSuccessfully);
        }

        public async Task<ApiPagedResponse<Actor>> UpdateRangeAsync(IList<Actor> actors)
        {
            IList<Actor> updatedActors = await _actorRepository.UpdateRangeAsync(actors);
            return new ApiPagedResponse<Actor>(updatedActors, ActorServiceMessages.ActorsUpdatedSuccessfully);
        }

        public async Task<ApiPagedResponse<Actor>> DeleteRangeAsync(IList<Actor> actors)
        {
            IList<Actor> deletedActors = await _actorRepository.DeleteRangeAsync(actors);
            return new ApiPagedResponse<Actor>(deletedActors, ActorServiceMessages.ActorsDeletedSuccessfully);
        }
    }
}
