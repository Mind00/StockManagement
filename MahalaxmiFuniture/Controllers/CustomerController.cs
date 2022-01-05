using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Services.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService _customerService, IMapper _mapper)
        {
            customerService = _customerService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> ListAsync()
        {
            var customerList = await customerService.ListAsync();
            var dto = mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customerList);
            return dto;
        }

        [HttpGet("{id}")]
        public async Task<CustomerDto> GetCustomer(int id)
        {
            var customer = await customerService.FindById(id);
            var dto = mapper.Map<Customer, CustomerDto>(customer.Data);
            return dto;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerDto customerDto)
        {
            var dto = mapper.Map<CustomerDto, Customer>(customerDto);
            var customer = await customerService.CreateAsync(dto);
            if (customer.IsSuccess)
            {
                var result = mapper.Map<Customer, CustomerDto>(customer.Data);
                return Ok(result);
            }
            else
            {
                return BadRequest(customer.Errors);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDto customerDto)
        {
            var customer = mapper.Map<CustomerDto, Customer>(customerDto);
            var dto = await customerService.UpdateAsync(id, customer);
            if (dto.IsSuccess)
            {
                var result = mapper.Map<Customer, CustomerDto>(dto.Data);
                return Ok(result);
            }
            else
            {
                return BadRequest(dto.Errors);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await customerService.DeleteAsync(id);
            if (customer.IsSuccess)
            {
                return Ok(200);
            }
            else
            {
                return BadRequest(customer.Errors);
            }
        }

    }
}
