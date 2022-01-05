using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitofWork;

        public CustomerService(ICustomerRepository _repo, IUnitOfWork _work)
        {
            customerRepository = _repo;
            unitofWork = _work;
        }
        public async Task<ServiceResponse<Customer>> CreateAsync(Customer customer)
        {
            ServiceResponse<Customer> serviceResponse = new ServiceResponse<Customer>();
            customer.postedOn = DateTime.Now;
            customer.userId = 1;
            try
            {
                await customerRepository.CreateAsync(customer);
                await unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "New Record Added successfully.";
                return serviceResponse;
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Errors = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Customer>> DeleteAsync(int id)
        {
            ServiceResponse<Customer> serviceResponse = new ServiceResponse<Customer>();
            var existingCustomer = await customerRepository.GetCustomerById(id);
            if (existingCustomer == null)
            {
                try
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Not found.";
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
                customerRepository.DeleteAsync(existingCustomer);
                await unitofWork.CompleteAsync();
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Record deleted successfully.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Customer>> FindById(int id)
        {
            ServiceResponse<Customer> serviceResponse = new ServiceResponse<Customer>();
            try
            {
                var record = await customerRepository.GetCustomerById(id);
                if (record == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Record Not Found.";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Data = record;
                    return serviceResponse;
                }
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Errors = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            ServiceResponse<Customer> serviceResponse = new ServiceResponse<Customer>();
            try
            {
                var customerList = await customerRepository.GetCustomer();
                if (customerList == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Empty Record.";
                    return (IEnumerable<Customer>)serviceResponse;
                }
                else
                {
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Data = (Customer)customerList;
                    return (IEnumerable<Customer>)serviceResponse;
                }
            }catch(Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Errors = ex.Message;
                return (IEnumerable<Customer>)serviceResponse;
            }
        }

        public async Task<ServiceResponse<Customer>> UpdateAsync(int id, Customer customer)
        {
            ServiceResponse<Customer> serviceResponse = new ServiceResponse<Customer>();
            try
            {
                var existingCustomer = await customerRepository.GetCustomerById(id);
                if (existingCustomer == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Record Not Found.";
                    return serviceResponse;
                }
                else
                {
                    existingCustomer.customerName = customer.customerName;
                    existingCustomer.address = customer.address;
                    existingCustomer.contactNo = customer.contactNo;
                    existingCustomer.description = customer.description;
                    existingCustomer.postedOn = DateTime.Now;
                    existingCustomer.userId = 2;
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record updated Successfully.";
                    return serviceResponse;
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
