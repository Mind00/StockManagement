using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface IAccountHeadRepository
    {
        Task<IEnumerable<AccountHead>> GetAccountHeads();
        Task<AccountHead> GetAccHeadById(int id);
        Task<AccountHead> GetAccHeadByName(string accHeadname);
        Task CreateAsync(AccountHead accountHead);
        void UpdateAsync(AccountHead accountHead);
        void DeleteAsync(AccountHead accountHead);
    }
}
