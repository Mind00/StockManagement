using MahalaxmiFuniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> ListAsync();
        Task<Stock> GetStockById(int id);
        Task CreateAsync(Stock stock);
        void UpdateAsync(Stock stock);
        void DeletedAsync(Stock stock);
    }
}
