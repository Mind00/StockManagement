using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.Stocks
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> ListAsync();
        Task<ServiceResponse<Stock>> GetStockById(int id);
        Task<ServiceResponse<Stock>> CreateAsync(Stock stock);
        Task<ServiceResponse<Stock>> UpdateAsync(int id,Stock stock);
        Task<ServiceResponse<Stock>> DeleteAsync(int id);
    }
}
