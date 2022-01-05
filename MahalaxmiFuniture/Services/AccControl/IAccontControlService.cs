using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.AccControl
{
    public interface IAccontControlService
    {
        Task <IEnumerable<AccountControl>> GetListAsync();
        Task<ServiceResponse<AccountControl>> GetAccCtrlById(int id);
        Task<ServiceResponse<AccountControl>> CreateAsync(AccountControl accountControl);
        Task<ServiceResponse<AccountControl>> UpdateAsync(int id, AccountControl accountControl);
        Task<ServiceResponse<AccountControl>> DeleteAsync(int id);
    }
}
