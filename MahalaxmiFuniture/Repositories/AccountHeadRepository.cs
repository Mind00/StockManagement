using MahalaxmiFuniture.Context;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories
{
    public class AccountHeadRepository : IAccountHeadRepository
    {
        private readonly AppDbContext _context;
        public AccountHeadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(AccountHead accountHead)
        {
            await _context.AccountHeads.AddAsync(accountHead);
        }

        public void DeleteAsync(AccountHead accountHead)
        {
            _context.AccountHeads.Remove(accountHead);
        }

        public async Task<AccountHead> GetAccHeadById(int id)
        {
            return await _context.AccountHeads.SingleOrDefaultAsync(x=>x.accHeadId==id);
        }

        public async Task<IEnumerable<AccountHead>> GetAccountHeads()
        {
            return await _context.AccountHeads.ToListAsync();
        }
        public Task<AccountHead> GetAccHeadByName(string accHeadName)
        {
            return _context.AccountHeads.SingleOrDefaultAsync(x => x.accHeadName == accHeadName);
        }

        public void UpdateAsync( AccountHead accountHead)
        {
            _context.AccountHeads.Update(accountHead);
        }
    }
}
