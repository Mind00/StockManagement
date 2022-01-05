using MahalaxmiFuniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface IAccountSubControlRepository
    {
        Task<IEnumerable<AccountSubControl>> GetAccSubControls();
        Task<AccountSubControl> GetAccSubCtrlById(int id);
        Task CreateAsync(AccountSubControl accountSubControl);
        void UpdateAsync(AccountSubControl accountSubControl);
        void DeleteAsync(AccountSubControl accountSubControl);
    }
}
