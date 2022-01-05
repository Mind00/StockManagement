using MahalaxmiFuniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> ListAsync();
        Task<Supplier> GetSupplierById(int id);
        Task<Supplier> GetSupplierByName(string name);
        Task CreateAsync(Supplier supplier);
        void UpdateAsync(Supplier supplier);
        void DeleteAsync(Supplier supplier);
    }
}
