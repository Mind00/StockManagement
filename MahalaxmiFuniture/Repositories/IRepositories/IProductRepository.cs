using MahalaxmiFuniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task AddProduct(Product product);
        Task<Product> GetProductById(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
