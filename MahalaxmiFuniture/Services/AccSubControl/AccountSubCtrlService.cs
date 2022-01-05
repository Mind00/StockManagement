using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.AccSubControl
{
    public class AccountSubCtrlService : IAccountSubCtrlService
    {
        private readonly IAccountSubControlRepository accountSubCtrlRepository;
        private readonly IUnitOfWork unitofWork;

        public AccountSubCtrlService(IAccountSubControlRepository controlRepository, IUnitOfWork _unitofWork)
        {
            accountSubCtrlRepository = controlRepository;
            unitofWork = _unitofWork;
        }
        public async Task<ServiceResponse<AccountSubControl>> CreateAsync(AccountSubControl accountSub)
        {
            ServiceResponse<AccountSubControl> serviceResponse = new ServiceResponse<AccountSubControl>();
            accountSub.postedOn = DateTime.Now;
            accountSub.userId = 1;
            try
            {
                await accountSubCtrlRepository.CreateAsync(accountSub);
                await unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "New Record Added Successfully.";
                return serviceResponse;
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "An error occured while adding new record.";
                serviceResponse.Errors = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<AccountSubControl>> DeleteAsync(int id)
        {
            ServiceResponse<AccountSubControl> serviceResponse = new ServiceResponse<AccountSubControl>();
            var result = await accountSubCtrlRepository.GetAccSubCtrlById(id);
            if (result == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Not Found.";
                return serviceResponse;
            }
            else
            {
                try
                {
                    accountSubCtrlRepository.DeleteAsync(result);
                    await unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record deleted successfully.";
                    return serviceResponse;
                }catch(Exception ex)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Errors = ex.Message;
                    return serviceResponse;
                }
            }
        }

        public async Task<ServiceResponse<AccountSubControl>> GetById(int id)
        {
            ServiceResponse<AccountSubControl> serviceResponse = new ServiceResponse<AccountSubControl>();
            var acc = await accountSubCtrlRepository.GetAccSubCtrlById(id);
            if (acc == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Not Found.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Data = acc;
                return serviceResponse;
            }
        }

        public async Task<IEnumerable<AccountSubControl>> ListAsync()
        {
            ServiceResponse<AccountSubControl> serviceResponse = new ServiceResponse<AccountSubControl>();
            try
            {
                var result = await accountSubCtrlRepository.GetAccSubControls();
                if (result == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Records Not Found";
                    return (IEnumerable<AccountSubControl>)serviceResponse;
                }
                else
                {
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Records Fetched Successfully.";
                    serviceResponse.Data = (AccountSubControl)result;
                    return (IEnumerable<AccountSubControl>)serviceResponse;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "An error occured while fetching record.";
                serviceResponse.Errors = ex.Message;
                return (IEnumerable<AccountSubControl>)serviceResponse;
            }
        }

        public async Task<ServiceResponse<AccountSubControl>> UpdateAsync(int id, AccountSubControl accountSub)
        {
            ServiceResponse<AccountSubControl> serviceResponse = new ServiceResponse<AccountSubControl>();
            var existingRecord = await accountSubCtrlRepository.GetAccSubCtrlById(id);
            if (existingRecord == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Not Found";
                return serviceResponse;
            }
            else
            {
                existingRecord.accHeadId = accountSub.accHeadId;
                existingRecord.accControlId = accountSub.accControlId;
                existingRecord.accSubControlName = accountSub.accSubControlName;
                existingRecord.postedOn = accountSub.postedOn;
                existingRecord.userId = 1;
                try
                {
                    accountSubCtrlRepository.UpdateAsync(existingRecord);
                    await unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record Updated Successfully.";
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
