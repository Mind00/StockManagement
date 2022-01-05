using MahalaxmiFuniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task AddCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string categoryName);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
