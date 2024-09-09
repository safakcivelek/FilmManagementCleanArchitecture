using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Purchases.Constants;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<ApiResponse<Purchase>?> GetAsync(Expression<Func<Purchase, bool>> predicate, Func<IQueryable<Purchase>, IIncludableQueryable<Purchase, object>>? include = null, bool enableTracking = true, bool withDeleted = false)
        {
            Purchase? purchase = await _purchaseRepository.GetAsync(predicate, include, enableTracking, withDeleted);
            if (purchase == null)
                return new ApiResponse<Purchase>(purchase, PurchaseServiceMessages.PurchasedFilmNotFound, 404);
            return new ApiResponse<Purchase>(purchase, PurchaseServiceMessages.FilmRetrievedSuccessfully);
        }

        public async Task<ApiPagedResponse<Purchase>> GetListAsync(
            Expression<Func<Purchase, bool>>? predicate = null,
            Func<IQueryable<Purchase>, IOrderedQueryable<Purchase>>? orderBy = null,
            Func<IQueryable<Purchase>, IIncludableQueryable<Purchase, object>>? include = null,
            bool enableTracking = true, bool withDeleted = false, int? skip = 0, int? take = 10)
        {
            IList<Purchase> purchaseList = await _purchaseRepository.GetListAsync(predicate, orderBy, include, enableTracking, withDeleted, skip, take);
            if (purchaseList.Count == 0)
                return new ApiPagedResponse<Purchase>(purchaseList, PurchaseServiceMessages.PurchasedFilmNotFound, 404);
            return new ApiPagedResponse<Purchase>(purchaseList, PurchaseServiceMessages.PurchasedFilmsListedSuccessfully);
        }

        public async Task<bool> AnyAsync(Expression<Func<Purchase, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false)
        {
            bool purchaseExists = await _purchaseRepository.AnyAsync(predicate, enableTracking, withDeleted);
            return purchaseExists;
        }

        public async Task<int> CountAsync(Expression<Func<Purchase, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false)
        {
            int purchaseCount = await _purchaseRepository.CountAsync(predicate, enableTracking, withDeleted);
            return purchaseCount;
        }

        public async Task<ApiResponse<Purchase>> AddAsync(Purchase purchase)
        {
            Purchase addedPurchase = await _purchaseRepository.AddAsync(purchase);
            return new ApiResponse<Purchase>(addedPurchase, PurchaseServiceMessages.FilmPurchasedSuccessfully);
        }

        public async Task<ApiResponse<Purchase>> UpdateAsync(Purchase purchase)
        {
            Purchase updatedPurchase = await _purchaseRepository.UpdateAsync(purchase);
            return new ApiResponse<Purchase>(updatedPurchase, PurchaseServiceMessages.PurchasedFilmUpdatedSuccessfully);
        }

        public async Task<ApiResponse<Purchase>> DeleteAsync(Purchase purchase)
        {
            Purchase deletedPurchase = await _purchaseRepository.DeleteAsync(purchase);
            return new ApiResponse<Purchase>(deletedPurchase, PurchaseServiceMessages.PurchasedFilmDeletedSuccessfully);
        }
    }
}
