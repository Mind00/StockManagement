using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Services.Suppliers;
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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SupplierDto>> Get()
        {
            var result = await _supplierService.ListAsync();
            var dto = _mapper.Map<IEnumerable<Supplier>,IEnumerable<SupplierDto>>(result);
            return dto;
        }

        [HttpGet("{id}")]
        public async Task<SupplierDto> Get(int id)
        {
            var result = await _supplierService.GetSupplierById(id);
            var dto = _mapper.Map<Supplier, SupplierDto>(result.Data);
            return dto;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupplierDto supplierDto)
        {
            var dto = _mapper.Map<SupplierDto, Supplier>(supplierDto);
            var result = await _supplierService.CreateAsync(dto);
            if (result.IsSuccess)
            {
                var data = _mapper.Map<Supplier, SupplierDto>(result.Data);
                return Ok(data);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SupplierDto supplierDto)
        {
            var dto = _mapper.Map<SupplierDto, Supplier>(supplierDto);
            var result = await _supplierService.UpdateAsync(id, dto);
            if (result.IsSuccess)
            {
                var data = _mapper.Map<Supplier, SupplierDto>(result.Data);
                return Ok(data);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _supplierService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
