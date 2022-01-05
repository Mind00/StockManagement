using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.AccSubControl
{
    public interface IAccountSubCtrlService
    {
        Task<IEnumerable<AccountSubControl>> ListAsync();
        Task<ServiceResponse<AccountSubControl>> GetById(int id);
        Task<ServiceResponse<AccountSubControl>> CreateAsync(AccountSubControl accountSub);
        Task<ServiceResponse<AccountSubControl>> UpdateAsync(int id, AccountSubControl accountSub);
        Task<ServiceResponse<AccountSubControl>> DeleteAsync(int id);
    }
}
