using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.AccHead
{
    public class AccountHeadService : IAccountHeadService
    {
        private readonly IAccountHeadRepository _accHeadRepo;
        private readonly IUnitOfWork _unitofWork;
        public AccountHeadService(IAccountHeadRepository accountHeadRepository, IUnitOfWork unitofWork)
        {
            _accHeadRepo = accountHeadRepository;
            _unitofWork = unitofWork;
        }

        public async Task<ServiceResponse<AccountHead>> DeleteAsync(int id)
        {
            ServiceResponse<AccountHead> serviceResponse = new ServiceResponse<AccountHead>();
            var result = await _accHeadRepo.GetAccHeadById(id);
            if (result == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record not found.";
                return serviceResponse;
            }
            else
            {
                try { 
                 _accHeadRepo.DeleteAsync(result);
                await _unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "Record deleted successfully";
                    return serviceResponse;
                }
                catch(Exception ex) {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "An error occured while deleting a record.";
                    serviceResponse.Errors = ex.Message;
                    return serviceResponse;
                }
            }
        }

        public async Task<ServiceResponse<AccountHead>> FindByAccHeadName(string accHeadName)
        {
            ServiceResponse<AccountHead> serviceResponse = new ServiceResponse<AccountHead>();
            var result = await _accHeadRepo.GetAccHeadByName(accHeadName);
            if (result == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Given Account Head name do not exist.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "Given Account Head name already exist.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<AccountHead>> GetAccHeadById(int id)
        {
            ServiceResponse<AccountHead> serviceResponse = new ServiceResponse<AccountHead>();
            var result = await _accHeadRepo.GetAccHeadById(id);
            if (result == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "No Record Found.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Data = result;
                return serviceResponse;
            }
        }

        public async Task<IEnumerable<AccountHead>> ListAsync()
        {
            var accountList = await _accHeadRepo.GetAccountHeads();
            return accountList;
        }

        public async Task<ServiceResponse<AccountHead>> SaveAsync(AccountHead acc)
        {
            ServiceResponse<AccountHead> serviceResponse = new ServiceResponse<AccountHead>();
            try { 
            var existingAccountHead = await _accHeadRepo.GetAccHeadByName(acc.accHeadName);
            if (existingAccountHead == null)
            {
                acc.userId = 4;
                acc.postedOn = DateTime.Now;
                await _accHeadRepo.CreateAsync(acc);
                await _unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "Record Added Successfully.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Account Head already exist.";
                return serviceResponse;
            }
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "An error occured while adding data.";
                serviceResponse.Errors = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<AccountHead>> UpdateAsync(int id, AccountHead acc)
        {
            ServiceResponse<AccountHead> serviceResponse = new ServiceResponse<AccountHead>();
             var existingRecord = await _accHeadRepo.GetAccHeadById(id);
            if (existingRecord == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "No Record Found.";
                return serviceResponse;
            }
            else
            {
                existingRecord.accHeadName = acc.accHeadName;
                existingRecord.userId = 4;
                existingRecord.postedOn = DateTime.Now;
                try
                {
                    await _accHeadRepo.CreateAsync(existingRecord);
                    await _unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record Updated Successfully.";
                    return serviceResponse;
                }
                catch (Exception ex)
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
