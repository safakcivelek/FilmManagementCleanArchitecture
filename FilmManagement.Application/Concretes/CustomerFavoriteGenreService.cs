
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes
{
    public class CustomerFavoriteGenreService :ICustomerFavoriteGenreService
    {
        private readonly ICustomerFavoriteGenreRepository  _customerFavoriteGenreRepository;
        public CustomerFavoriteGenreService(ICustomerFavoriteGenreRepository customerFavoriteGenreRepository)
        {
            _customerFavoriteGenreRepository = customerFavoriteGenreRepository;
        }

        public async Task<CustomerFavoriteGenre?> GetAsync(Expression<Func<CustomerFavoriteGenre, bool>> predicate, Func<IQueryable<CustomerFavoriteGenre>, IIncludableQueryable<CustomerFavoriteGenre, object>>? include = null, bool enableTracking = true)
        {
            CustomerFavoriteGenre?  customerFavoriteGenre = await _customerFavoriteGenreRepository.GetAsync(predicate, include, enableTracking);
            return customerFavoriteGenre;
        }

        public async Task<IList<CustomerFavoriteGenre>> GetListAsync(Expression<Func<CustomerFavoriteGenre, bool>>? predicate = null, Func<IQueryable<CustomerFavoriteGenre>, IIncludableQueryable<CustomerFavoriteGenre, object>>? include = null, bool enableTracking = true)
        {
            IList<CustomerFavoriteGenre> customerFavoriteGenreList = await _customerFavoriteGenreRepository.GetListAsync(predicate, include, enableTracking);
            return customerFavoriteGenreList;
        }

        public async Task<CustomerFavoriteGenre> AddAsync(CustomerFavoriteGenre  customerFavoriteGenre)
        {
            CustomerFavoriteGenre addedCustomerFavoriteGenre = await _customerFavoriteGenreRepository.AddAsync(customerFavoriteGenre);
            return addedCustomerFavoriteGenre;
        }

        public async Task<CustomerFavoriteGenre> UpdateAsync(CustomerFavoriteGenre customerFavoriteGenre)
        {
            CustomerFavoriteGenre updatedCustomerFavoriteGenre = await _customerFavoriteGenreRepository.UpdateAsync(customerFavoriteGenre);
            return updatedCustomerFavoriteGenre;
        }
        public async Task<CustomerFavoriteGenre> DeleteAsync(CustomerFavoriteGenre customerFavoriteGenre)
        {
            CustomerFavoriteGenre deletedCustomerFavoriteGenre = await _customerFavoriteGenreRepository.DeleteAsync(customerFavoriteGenre);
            return deletedCustomerFavoriteGenre;
        }
    }
}
