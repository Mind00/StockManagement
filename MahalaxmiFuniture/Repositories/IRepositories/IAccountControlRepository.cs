using MahalaxmiFuniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface IAccountControlRepository
    {
        Task <IEnumerable<AccountControl>> GetAccControlList();
        Task<AccountControl> GetAccControlById(int id);
        Task CreateAsync(AccountControl accountControl);
        void UpdateAsync(AccountControl accountControl);
        void DeleteAsync(AccountControl accountControl);
    }
}
