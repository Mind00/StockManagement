using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Services.Stocks;
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
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        public StockController(IStockService stockService, IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StockDto>> Get()
        {
            var dto = await _stockService.ListAsync();
            var result = _mapper.Map<IEnumerable<Stock>,IEnumerable<StockDto>>(dto);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<StockDto>Get(int id)
        {
            var dto = await _stockService.GetStockById(id);
            var result = _mapper.Map<Stock, StockDto>(dto.Data);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post(StockDto stockDto)
        {
            var dto = _mapper.Map<StockDto, Stock>(stockDto);
            var result = await _stockService.CreateAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, [FromBody]StockDto stockDto) 
        {
            var dto = _mapper.Map<StockDto, Stock>(stockDto);
            var data = await _stockService.UpdateAsync(id, dto);
            if (data.IsSuccess)
            {
                var result = _mapper.Map<Stock, StockDto>(data.Data);
                return Ok(result);
            }
            else
            {
                return BadRequest(data.Errors);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _stockService.DeleteAsync(id);
            if (dto.IsSuccess)
            {
                return Ok(dto.Message);
            }
            else
            {
                return BadRequest(dto.Errors);
            }
        }
    }
}
