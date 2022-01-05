using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ServiceResponse<Product>> GetProductById(int id);
        Task<ServiceResponse<Product>> SaveAsync(Product product);
        Task<ServiceResponse<Product>> UpdateAsync(int id, Product product);
        Task<ServiceResponse<Product>> DeleteAsync(int id);
    }
}
