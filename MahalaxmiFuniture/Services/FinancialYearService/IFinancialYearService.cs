using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.FinancialYearService
{
    public interface IFinancialYearService
    {
        Task<IEnumerable<FinancialYear>> ListAsync();
        Task<ServiceResponse<FinancialYear>> GetFinancialYearById(int id);
        Task<ServiceResponse<FinancialYear>> CreateAsync(FinancialYear financialYear);
        Task<ServiceResponse<FinancialYear>> UpdateAsync(int id, FinancialYear financialYear);
        Task<ServiceResponse<FinancialYear>> DeleteAsync(int id);
    }
}
