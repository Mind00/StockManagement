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
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;
        public StockRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
        }

        public void DeletedAsync(Stock stock)
        {
            _context.Stocks.Remove(stock);
        }

        public async Task<Stock> GetStockById(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<IEnumerable<Stock>> ListAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public void UpdateAsync(Stock stock)
        {
            _context.Stocks.Update(stock);
        }
    }
}
