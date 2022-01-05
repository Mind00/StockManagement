using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.AccHead
{
    public interface IAccountHeadService
    {
        Task<IEnumerable<AccountHead>> ListAsync();
        Task<ServiceResponse<AccountHead>> GetAccHeadById(int id);
        Task<ServiceResponse<AccountHead>> FindByAccHeadName(string accHeadName);
        Task<ServiceResponse<AccountHead>> SaveAsync(AccountHead acc);
        Task<ServiceResponse<AccountHead>> UpdateAsync(int id, AccountHead acc);
        Task<ServiceResponse<AccountHead>> DeleteAsync(int id);
    }
}
