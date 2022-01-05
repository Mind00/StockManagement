using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Services.AccHead;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MahalaxmiFuniture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccHeadController : ControllerBase
    {
        private readonly IAccountHeadService accHeadService;
        private readonly IMapper mapper;
        public AccHeadController(IAccountHeadService _accountHeadService, IMapper _mapper)
        {
            accHeadService = _accountHeadService;
            mapper = _mapper;
        }
        // GET: api/<AccHeadController>
        [HttpGet]
        public async Task<IEnumerable<AccHeadDto>> GetAccHeadList()
        {
            var accList = await accHeadService.ListAsync();
            var dto =  mapper.Map<IEnumerable<AccountHead>, IEnumerable<AccHeadDto>>(accList);
            return dto;
        }

        // GET api/<AccHeadController>/5
        [HttpGet("{id}")]
        public async Task<AccHeadDto> Get(int id)
        {
            var acc = await accHeadService.GetAccHeadById(id);
            var dto = mapper.Map<AccountHead, AccHeadDto>(acc.Data);
            return dto;
        }

        // POST api/<AccHeadController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccHeadDto accHeadDto)
        {
            var result = mapper.Map<AccHeadDto, AccountHead>(accHeadDto);
            var acc = await accHeadService.SaveAsync(result);
            if (!acc.IsSuccess)
            {
                return BadRequest(acc.Errors);
            }
            var dto = mapper.Map<AccountHead, AccHeadDto>(acc.Data);
            return Ok(dto);
        }

        // PUT api/<AccHeadController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AccHeadDto accHeadDto)
        {
            var result=mapper.Map<AccHeadDto, AccountHead>(accHeadDto);
            var acc = await accHeadService.UpdateAsync(id,result);
            if (acc.IsSuccess)
            {
                var dto = mapper.Map<AccountHead, AccHeadDto>(acc.Data);
                return Ok(dto);
            }
            else
            {
                return BadRequest(acc.Errors);
            }
        }

        // DELETE api/<AccHeadController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await accHeadService.DeleteAsync(id);
            if (result.IsSuccess) 
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
