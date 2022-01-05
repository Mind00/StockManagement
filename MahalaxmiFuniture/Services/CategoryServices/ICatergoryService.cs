using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.CategoryServices
{
    public interface ICatergoryService
    {
        Task<IEnumerable<Category>>ListAsync();
        Task<ServiceResponse<Category>> GetCategoryById(int id);
        Task<Category> FindByCategoryName(string category);
        Task<ServiceResponse<Category>> SaveAsync(Category category);
        Task<ServiceResponse<Category>> UpdateAsync(int id, Category category);
        Task<ServiceResponse<Category>> DeleteAsync(int id);
    }
}
