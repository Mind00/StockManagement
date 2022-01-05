using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<ServiceResponse<Customer>> FindById(int id);
        Task<ServiceResponse<Customer>> CreateAsync(Customer customer);
        Task<ServiceResponse<Customer>> UpdateAsync(int id, Customer customer);
        Task<ServiceResponse<Customer>> DeleteAsync(int id);
    }
}
