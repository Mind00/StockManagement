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
    public class FinancialYearRepository : IFinancialYearRepository
    {
        private readonly AppDbContext context;

        public FinancialYearRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task CreateAsync(FinancialYear financialYear)
        {
            await context.FinancialYears.AddAsync(financialYear);
        }

        public void DeleteAsync(FinancialYear financialYear)
        {
            context.FinancialYears.Remove(financialYear);
        }

        public async Task<FinancialYear> GetFinancialYearById(int id)
        {
            return await context.FinancialYears.FindAsync(id);
        }

        public async Task<IEnumerable<FinancialYear>> GetFinancialYears()
        {
            return await context.FinancialYears.ToListAsync();
        }


        public void UpdateAsync(FinancialYear financialYear)
        {
            context.FinancialYears.Update(financialYear);
        }
    }
}
