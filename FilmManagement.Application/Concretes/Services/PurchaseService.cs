using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
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

        public async Task<Purchase?> GetAsync(Expression<Func<Purchase, bool>> predicate, Func<IQueryable<Purchase>, IIncludableQueryable<Purchase, object>>? include = null, bool enableTracking = true)
        {
            Purchase? purchase = await _purchaseRepository.GetAsync(predicate, include, enableTracking);
            return purchase;
        }

        public async Task<IList<Purchase>> GetListAsync(Expression<Func<Purchase, bool>>? predicate = null, Func<IQueryable<Purchase>, IIncludableQueryable<Purchase, object>>? include = null, bool enableTracking = true)
        {
            IList<Purchase> purchaseList = await _purchaseRepository.GetListAsync(predicate, include, enableTracking);
            return purchaseList;
        }

        public async Task<Purchase> AddAsync(Purchase purchase)
        {
            Purchase addedPurchase = await _purchaseRepository.AddAsync(purchase);
            return addedPurchase;
        }

        public async Task<Purchase> UpdateAsync(Purchase purchase)
        {
            Purchase updatedPurchase = await _purchaseRepository.UpdateAsync(purchase);
            return updatedPurchase;
        }
        public async Task<Purchase> DeleteAsync(Purchase purchase)
        {
            Purchase deletedPurchase = await _purchaseRepository.DeleteAsync(purchase);
            return deletedPurchase;
        }
    }
}
