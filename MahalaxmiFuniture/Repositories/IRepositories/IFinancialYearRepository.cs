using MahalaxmiFuniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface IFinancialYearRepository
    {
        Task<IEnumerable<FinancialYear>> GetFinancialYears();
        Task<FinancialYear> GetFinancialYearById(int id);
        Task CreateAsync(FinancialYear financialYear);
        void UpdateAsync(FinancialYear financialYear);
        void DeleteAsync(FinancialYear financialYear);
    }
}
