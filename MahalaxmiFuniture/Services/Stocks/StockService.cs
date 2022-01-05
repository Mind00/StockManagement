using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.Stocks
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IUnitOfWork _unitofWork;

        public StockService(IStockRepository stockRepository, IUnitOfWork unitofWork)
        {
            _stockRepository = stockRepository;
            _unitofWork = unitofWork;
        }
        public async Task<ServiceResponse<Stock>> CreateAsync(Stock stock)
        {
            ServiceResponse<Stock> serviceResponse = new ServiceResponse<Stock>();
            stock.postedOn = DateTime.Now;
            stock.userId = 1;
            try
            {
                await _stockRepository.CreateAsync(stock);
                await _unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "New Record Added Successfully.";
                return serviceResponse;
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Errors = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Stock>> DeleteAsync(int id)
        {
            ServiceResponse<Stock> serviceResponse = new ServiceResponse<Stock>();
            var result = await _stockRepository.GetStockById(id);
            if (result == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Not Found.";
                return serviceResponse;
            }
            else
            {
                _stockRepository.DeletedAsync(result);
                await _unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "Record Deleted Successfully.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Stock>> GetStockById(int id)
        {
            ServiceResponse<Stock> serviceResponse = new ServiceResponse<Stock>();
            var result = await _stockRepository.GetStockById(id);
            if (result == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Not Found.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Data = result;
                return serviceResponse;
            }
        }

        public async Task<IEnumerable<Stock>> ListAsync()
        {
            ServiceResponse<Stock> serviceResponse = new ServiceResponse<Stock>();
            try
            {
                var result = await _stockRepository.ListAsync();
                if (result == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Records are Empty.";
                    return (IEnumerable<Stock>)serviceResponse;
                }
                else
                {
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Data = (Stock)result;
                    return (IEnumerable<Stock>)serviceResponse;
                }
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Errors = ex.Message;
                return (IEnumerable<Stock>)serviceResponse;
            }
        }

        public async Task<ServiceResponse<Stock>> UpdateAsync(int id,Stock stock)
        {
            ServiceResponse<Stock> serviceResponse = new ServiceResponse<Stock>();
            var existingStock = await _stockRepository.GetStockById(id);
            if (existingStock == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "No Record Found.";
                return serviceResponse;
            }
            else
            {
                try
                {
                    existingStock.cId = stock.cId;
                    existingStock.pId = stock.pId;
                    existingStock.quantity = stock.quantity;
                    existingStock.saleUnitPrice = stock.saleUnitPrice;
                    existingStock.currentPurchaseUnitPrice = stock.currentPurchaseUnitPrice;
                    existingStock.manufactureDate = stock.manufactureDate;
                    existingStock.description = stock.description;
                    existingStock.postedOn = stock.postedOn;
                    existingStock.userId = 2;
                    _stockRepository.UpdateAsync(existingStock);
                    await _unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record Updated Successfully.";
                    return serviceResponse;
                }catch(Exception ex)
                {
                    serviceResponse.Errors = ex.Message;
                    return serviceResponse;
                }
            }
        }
    }
}
