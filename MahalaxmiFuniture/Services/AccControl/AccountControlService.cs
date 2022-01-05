using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.AccControl
{
    public class AccountControlService : IAccontControlService
    {
        private readonly IAccountControlRepository accountControlRepository;
        private readonly IUnitOfWork unitofWork;

        public AccountControlService(IAccountControlRepository _accCtrlRepo, IUnitOfWork _unitofWork)
        {
            accountControlRepository = _accCtrlRepo;
            unitofWork = _unitofWork;
        }
        public async Task<ServiceResponse<AccountControl>> CreateAsync(AccountControl accountControl)
        {
            ServiceResponse<AccountControl> serviceResponse = new ServiceResponse<AccountControl>();
            accountControl.postedOn = DateTime.Now;
            accountControl.userId = 1;
            try
            {
                await accountControlRepository.CreateAsync(accountControl);
                await unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "New Record Added Successfully.";
                return serviceResponse;
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "An Error occured while adding new data.";
                serviceResponse.Errors = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<AccountControl>> DeleteAsync(int id)
        {
            ServiceResponse<AccountControl> serviceResponse = new ServiceResponse<AccountControl>();
            var existingRecord = await accountControlRepository.GetAccControlById(id);
            if (existingRecord == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "No Record Found.";
                return serviceResponse;
            }
            else
            {
                try
                {
                    accountControlRepository.DeleteAsync(existingRecord);
                    await unitofWork.CompleteAsync(); 
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record deleted successfully.";
                    return serviceResponse;
                }catch(Exception ex)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "An error occured while deleting a record.";
                    serviceResponse.Errors = ex.Message;
                    return serviceResponse;
                }
            }
        }

        public async Task<ServiceResponse<AccountControl>> GetAccCtrlById(int id)
        {
            ServiceResponse<AccountControl> serviceResponse = new ServiceResponse<AccountControl>();
            var existingRecord = await accountControlRepository.GetAccControlById(id);
            if (existingRecord == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Not Found.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Data = existingRecord;
                return serviceResponse;
            }
        }

        public async Task<IEnumerable<AccountControl>> GetListAsync()
        {
            ServiceResponse<AccountControl> serviceResponse = new ServiceResponse<AccountControl>();
            try
            {
                var result = await accountControlRepository.GetAccControlList();
                if (result == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Records Not Found.";
                    return (IEnumerable<AccountControl>)serviceResponse;
                }
                else
                {
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Data = (AccountControl)result;
                    return (IEnumerable<AccountControl>)serviceResponse;
                }
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Errors = ex.Message;
                return (IEnumerable<AccountControl>)serviceResponse;
            }
        }

        public async Task<ServiceResponse<AccountControl>> UpdateAsync(int id, AccountControl accountControl)
        {
            ServiceResponse<AccountControl> serviceResponse = new ServiceResponse<AccountControl>();
            var existingRecord = await accountControlRepository.GetAccControlById(id);
            if (existingRecord == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Not found.";
                return serviceResponse;
            }
            else
            {
                existingRecord.accHeadId = accountControl.accHeadId;
                existingRecord.accControlName = accountControl.accControlName;
                existingRecord.postedOn = DateTime.Now;
                existingRecord.userId = accountControl.userId;
                try
                {
                    accountControlRepository.UpdateAsync(existingRecord);
                    await unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record updated Successfully.";
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
