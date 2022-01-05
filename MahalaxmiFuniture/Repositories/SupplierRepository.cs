using MahalaxmiFuniture.Context;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;
        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
        }

        public void DeleteAsync(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task<Supplier> GetSupplierByName(string name)
        {
            return await _context.Suppliers.SingleOrDefaultAsync(x => x.supplierName == name);
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public void UpdateAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
        }
    }
}
