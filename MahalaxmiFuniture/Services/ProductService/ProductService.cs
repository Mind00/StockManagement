using AutoMapper;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitofWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitofWork)
        {
            _productRepository = productRepository;
            _unitofWork = unitofWork;
        }
        public async Task<ServiceResponse<Product>> DeleteAsync(int id)
        {
            ServiceResponse<Product> serviceResponse = new ServiceResponse<Product>();
            var product = await _productRepository.GetProductById(id);
            if(product == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Required Record do not found.";
                return serviceResponse;
            }
            try
            {
                 _productRepository.DeleteProduct(product);
                 await _unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "Record deleted successfully.";
                return serviceResponse;
            } catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "An error occured while deleting a record.";
                serviceResponse.Errors = ex.Message;
                return (serviceResponse);
            }
        }

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            ServiceResponse<Product> serviceResponse = new ServiceResponse<Product>();
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Not Found.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Data = product;
                return serviceResponse;
            }
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
                var productList = await _productRepository.GetProducts();
                int totalItems = productList.Count();
                return productList;
        }

        public async Task<ServiceResponse<Product>> SaveAsync(Product product)
        {
            ServiceResponse<Product> serviceResponse = new ServiceResponse<Product>();
            try
            {
                product.userId = 1;
                product.postedOn = DateTime.Now;
                await _productRepository.AddProduct(product);
                await _unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "New Record adderd successfully.";
                return serviceResponse;
            } 
            catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "An error occured while adding new product.";
                serviceResponse.Errors = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Product>> UpdateAsync(int id, Product product)
        {
            ServiceResponse<Product> serviceResponse = new ServiceResponse<Product>();
            var existingProduct = await _productRepository.GetProductById(id);
            if(existingProduct == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record not found";
                return serviceResponse;
            }
            else
            {
                try
                {
                    existingProduct.cId = product.cId;
                    existingProduct.productName = product.productName;
                    existingProduct.totalQuantity = product.totalQuantity;
                    existingProduct.UnitPrice = product.UnitPrice;
                    existingProduct.postedOn = product.postedOn;
                    existingProduct.userId = product.userId;
                    await _productRepository.AddProduct(existingProduct);
                    await _unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record updated successfully.";
                    serviceResponse.Data = existingProduct;
                    return serviceResponse;
                }catch(Exception ex)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "An error occured while updating a record.";
                    serviceResponse.Errors = ex.Message;
                    return serviceResponse;
                }
            }
        }
    }
}
