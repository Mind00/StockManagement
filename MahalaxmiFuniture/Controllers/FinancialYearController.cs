using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Services.FinancialYearService;
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
    public class FinancialYearController : ControllerBase
    {
        private readonly IFinancialYearService financialYearService;
        private readonly IMapper mapper;
        public FinancialYearController(IFinancialYearService service, IMapper _mapper)
        {
            financialYearService = service;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FinancialYearDto>> Get()
        {
            var result = await financialYearService.ListAsync();
            var dto = mapper.Map<IEnumerable<FinancialYear>, IEnumerable<FinancialYearDto>>(result);
            return dto ;
        }

        [HttpGet("{id}")]
        public async Task<FinancialYearDto> Get(int id)
        {
            var result = await financialYearService.GetFinancialYearById(id);
            var dto = mapper.Map<FinancialYear, FinancialYearDto>(result.Data);
            return dto;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FinancialYearDto financialYearDto)
        {
            var mappingDta = mapper.Map<FinancialYearDto, FinancialYear>(financialYearDto);
            var dto = await financialYearService.CreateAsync(mappingDta);
            if (dto.IsSuccess)
            {
                var result = mapper.Map<FinancialYear, FinancialYearDto>(dto.Data);
                return Ok(result);
            }
            else
            {
                return BadRequest(dto.Errors);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody]FinancialYearDto dto)
        {
            var mappingDta = mapper.Map<FinancialYearDto, FinancialYear>(dto);
            var dto1 = await financialYearService.UpdateAsync(id, mappingDta);
            if (dto1.IsSuccess)
            {
                var result = mapper.Map<FinancialYear, FinancialYearDto>(dto1.Data);
                return Ok(result);
            }
            else
            {
                return BadRequest(dto1.Errors);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await financialYearService.DeleteAsync(id);
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
