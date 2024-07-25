using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilmManagement.Application.Concretes.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer?> GetAsync(Expression<Func<Customer, bool>> predicate, Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null, bool enableTracking = true)
        {
            Customer? customer = await _customerRepository.GetAsync(predicate, include, enableTracking);
            return customer;
        }

        public async Task<IList<Customer>> GetListAsync(Expression<Func<Customer, bool>>? predicate = null, Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null, bool enableTracking = true)
        {
            IList<Customer> customerList = await _customerRepository.GetListAsync(predicate, include, enableTracking);
            return customerList;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            Customer addedCustomer = await _customerRepository.AddAsync(customer);
            return addedCustomer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            Customer updatedCustomer = await _customerRepository.UpdateAsync(customer);
            return updatedCustomer;
        }
        public async Task<Customer> DeleteAsync(Customer customer)
        {
            Customer deletedCustomer = await _customerRepository.DeleteAsync(customer);
            return deletedCustomer;
        }
    }
}
