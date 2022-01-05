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
    public class AccControlRepository :IAccountControlRepository
    {
        private readonly AppDbContext context;
        public AccControlRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task CreateAsync(AccountControl accountControl)
        {
            await context.AccountControls.AddAsync(accountControl);
        }

        public void DeleteAsync(AccountControl accountControl)
        {
            context.AccountControls.Remove(accountControl);
        }

        public async Task<AccountControl> GetAccControlById(int id)
        {
            return await context.AccountControls.FindAsync(id);
        }

        public async Task<IEnumerable<AccountControl>> GetAccControlList()
        {
            return await context.AccountControls.ToListAsync();
        }

        public void UpdateAsync(AccountControl accountControl)
        {
            context.AccountControls.Update(accountControl);
        }
    }
}
