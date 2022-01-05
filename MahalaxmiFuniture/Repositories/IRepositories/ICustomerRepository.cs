using MahalaxmiFuniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomer();
        Task<Customer> GetCustomerById(int id);
        Task CreateAsync(Customer customer);
        void UpdateAsync(Customer customer);
        void DeleteAsync(Customer customer);
    }
}
