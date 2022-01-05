using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.FinancialYearService
{
    public class FinancialYearService : IFinancialYearService
    {
        private readonly IFinancialYearRepository financialYearRepository;
        private readonly IUnitOfWork unitofWork;

        public FinancialYearService(IFinancialYearRepository _repository, IUnitOfWork _unitofWork)
        {
            financialYearRepository = _repository;
            unitofWork = _unitofWork;
        }
        public async Task<ServiceResponse<FinancialYear>> CreateAsync(FinancialYear financialYear)
        {
            ServiceResponse<FinancialYear> serviceResponse = new ServiceResponse<FinancialYear>();
            var existingYear = await financialYearRepository.GetFinancialYearById(financialYear.financialYearId);
            if (existingYear == null)
            {
                financialYear.postedOn = DateTime.Now;
                financialYear.userId = 1;
                try
                {
                    await financialYearRepository.CreateAsync(financialYear);
                    await unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record added successfully.";
                    return serviceResponse;
                }catch(Exception ex)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Errors = ex.Message;
                    return serviceResponse;
                }
            }
            else
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Financial year already exist.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<FinancialYear>> DeleteAsync(int id)
        {
            ServiceResponse<FinancialYear> serviceResponse = new ServiceResponse<FinancialYear>();
            var existYear = await financialYearRepository.GetFinancialYearById(id);
            if (existYear == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Not Found.";
                return serviceResponse;
            }
            else
            {
                try
                {
                    financialYearRepository.DeleteAsync(existYear);
                    await unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record deleted successfully";
                    return serviceResponse;
                }catch(Exception ex)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Errors = ex.Message;
                    return serviceResponse;
                }
            }
        }

        public async Task<ServiceResponse<FinancialYear>> GetFinancialYearById(int id)
        {
            ServiceResponse<FinancialYear> serviceResponse = new ServiceResponse<FinancialYear>();
            var finYear = await financialYearRepository.GetFinancialYearById(id);
            if (finYear == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Not Found.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Data = finYear;
                return serviceResponse;
            }
        }


        public async Task<IEnumerable<FinancialYear>> ListAsync()
        {
            ServiceResponse<FinancialYear> serviceResponse = new ServiceResponse<FinancialYear>();
            try
            {
                var yearList = await financialYearRepository.GetFinancialYears();
                if (yearList == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Record List is empty.";
                    return (IEnumerable<FinancialYear>)serviceResponse;
                }
                else
                {
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Data = (FinancialYear)yearList;
                    return (IEnumerable<FinancialYear>)serviceResponse;
                }
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Errors = ex.Message;
                return (IEnumerable<FinancialYear>)serviceResponse;
            }
        }

        public async Task<ServiceResponse<FinancialYear>> UpdateAsync(int id, FinancialYear financialYear)
        {
            ServiceResponse<FinancialYear> serviceResponse = new ServiceResponse<FinancialYear>();
            var existingYear = await financialYearRepository.GetFinancialYearById(id);
            if (existingYear == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record not found.";
                return serviceResponse;
            }
            else
            {
                try
                {
                    existingYear.postedOn = DateTime.Now;
                    existingYear.userId = 2;
                    financialYearRepository.UpdateAsync(existingYear);
                    await unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record updated successfully.";
                    return serviceResponse;
                }
                catch (Exception ex)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Errors = ex.Message;
                    return serviceResponse;
                }
            }
        }
    }
}
