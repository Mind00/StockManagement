using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.Suppliers
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> ListAsync();
        Task<ServiceResponse<Supplier>> GetSupplierById(int id);
        Task<ServiceResponse<Supplier>> GetSupplierByName(string name);
        Task<ServiceResponse<Supplier>> CreateAsync(Supplier supplier);
        Task<ServiceResponse<Supplier>> UpdateAsync(int id, Supplier supplier);
        Task<ServiceResponse<Supplier>> DeleteAsync(int id);
    }
}
