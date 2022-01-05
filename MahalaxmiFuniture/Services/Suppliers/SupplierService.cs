using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly IUnitOfWork _unitofWork;

        public SupplierService(ISupplierRepository repository, IUnitOfWork unitofWork)
        {
            _supplierRepo = repository;
            _unitofWork = unitofWork;
        }
        public async Task<ServiceResponse<Supplier>> CreateAsync(Supplier supplier)
        {
            ServiceResponse<Supplier> serviceResponse = new ServiceResponse<Supplier>();
            supplier.postedOn = DateTime.Now;
            supplier.userId = 1;
            try
            {
                var existingName = await _supplierRepo.GetSupplierByName(supplier.supplierName);
                if (existingName == null)
                {
                    await _supplierRepo.CreateAsync(supplier);
                    await _unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record added successfully.";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Supplier name already exist.";
                    return serviceResponse;
                }
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "An error occured while saving record.";
                serviceResponse.Errors = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Supplier>> DeleteAsync(int id)
        {
            ServiceResponse<Supplier> serviceResponse = new ServiceResponse<Supplier>();
            var existingRecord = await _supplierRepo.GetSupplierById(id);
            if (existingRecord == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Found Empty.";
                return serviceResponse;
            }
            else
            {
                try
                {
                    _supplierRepo.DeleteAsync(existingRecord);
                    await _unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record deleted successfully.";
                    return serviceResponse;
                }catch(Exception ex)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "An Error occured while deleting record.";
                    serviceResponse.Errors = ex.Message;
                    return serviceResponse;
                }
            }
        }

        public async Task<ServiceResponse<Supplier>> GetSupplierById(int id)
        {
            ServiceResponse<Supplier> serviceResponse = new ServiceResponse<Supplier>();
            var existingRecord = await _supplierRepo.GetSupplierById(id);
            if (existingRecord == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record Not Found.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Data = existingRecord;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Supplier>> GetSupplierByName(string name)
        {
            ServiceResponse<Supplier> serviceResponse = new ServiceResponse<Supplier>();
            var recordList = await _supplierRepo.GetSupplierByName(name);
            if (recordList == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "No record found with this name.";
                return serviceResponse;
            }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Message= "Supplier Name already exist.";
                return serviceResponse;
            }
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            ServiceResponse<Supplier> serviceResponse = new ServiceResponse<Supplier>();
            try
            {
                var recordList = await _supplierRepo.ListAsync();
                if (recordList == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Oops!! Record List is Empty.";
                    return (IEnumerable<Supplier>)serviceResponse;
                }
                else
                {
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Data = (Supplier)recordList;
                    return (IEnumerable<Supplier>)serviceResponse;
                }
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Errors = ex.Message;
                return (IEnumerable<Supplier>)serviceResponse;
            }
        }

        public async Task<ServiceResponse<Supplier>> UpdateAsync(int id, Supplier supplier)
        {
            ServiceResponse<Supplier> serviceResponse = new ServiceResponse<Supplier>();
            try
            {
                var existingRecord = await _supplierRepo.GetSupplierById(id);
                if (existingRecord == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "No record found.";
                    return serviceResponse;
                }
                else
                {
                    existingRecord.supplierName = supplier.supplierName;
                    existingRecord.supplierAddress = supplier.supplierAddress;
                    existingRecord.supplierContactNo = supplier.supplierContactNo;
                    existingRecord.email = supplier.email;
                    existingRecord.description = supplier.description;
                    existingRecord.postedOn = supplier.postedOn;
                    var existingName = await _supplierRepo.GetSupplierByName(supplier.supplierName);
                    if (existingName == null)
                    {
                        await _supplierRepo.CreateAsync(existingRecord);
                        await _unitofWork.CompleteAsync();
                        serviceResponse.IsSuccess = true;
                        return serviceResponse;
                    }
                    else
                    {
                        serviceResponse.IsSuccess = false;
                        serviceResponse.Message = "Supplier name already exist.";
                        return serviceResponse;
                    }
                }
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Errors = ex.Message;
                return serviceResponse;
            }
        }
    }
}
