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
    public class AccountSubControlRepository :IAccountSubControlRepository
    {
        private readonly AppDbContext context;

        public AccountSubControlRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task CreateAsync(AccountSubControl accountSubControl)
        {
             await context.AccountSubControls.AddAsync(accountSubControl);
        }

        public void DeleteAsync(AccountSubControl accountSubControl)
        {
            context.AccountSubControls.Remove(accountSubControl);
        }

        public async Task<IEnumerable<AccountSubControl>> GetAccSubControls()
        {
            var result = (from a in context.AccountSubControls
                          join b in context.AccountHeads on a.accHeadId equals b.accHeadId
                          select new
                          {
                              a.accSubControlId,
                              b.accHeadName,
                              a.accControlId,
                              a.accSubControlName,
                              a.User.fullName,
                              a.postedOn
                          }).ToListAsync();
            return (IEnumerable<AccountSubControl>)await result;
        }

        public async Task<AccountSubControl> GetAccSubCtrlById(int id)
        {
            return await context.AccountSubControls.FindAsync(id);
        }

        public void UpdateAsync(AccountSubControl accountSubControl)
        {
            context.AccountSubControls.Update(accountSubControl);
        }
    }
}
