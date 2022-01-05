using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Services.AccControl;
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
    public class AccountControlController : ControllerBase
    {
        private readonly IAccontControlService accontControlService;
        private readonly IMapper mapper;
        public AccountControlController(IAccontControlService _accCtrlService, IMapper _mapper)
        {
            accontControlService = _accCtrlService;
            mapper = _mapper;
        }
        // GET: api/<AccountControlController>
        [HttpGet]
        public async Task<IEnumerable<AccountControlDto>> Get()
        {
            var accCtrlList = await accontControlService.GetListAsync();
            var result = mapper.Map<IEnumerable<AccountControl>, IEnumerable<AccountControlDto>>(accCtrlList);
            return result;
        }

        // GET api/<AccountControlController>/5
        [HttpGet("{id}")]
        public async Task<AccountControlDto> Get(int id)
        {
            var accCtrlList = await accontControlService.GetAccCtrlById(id);
            var dto = mapper.Map<AccountControl, AccountControlDto>(accCtrlList.Data);
            return dto;
        }

        // POST api/<AccountControlController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountControlDto accountControl)
        {
            var addingData = mapper.Map<AccountControlDto, AccountControl>(accountControl);
            var accDto = await accontControlService.CreateAsync(addingData);
            if (accDto.IsSuccess)
            {
                var result = mapper.Map<AccountControl, AccountControlDto>(accDto.Data);
                return Ok(result);
            }
            else
            {
                return BadRequest(accDto.Errors);
            }
        }

        // PUT api/<AccountControlController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AccountControlDto dto)
        {
            var addingData = mapper.Map<AccountControlDto, AccountControl>(dto);
            var addingData1 = await accontControlService.UpdateAsync(id, addingData);
            if (addingData1.IsSuccess)
            {
                var dto1 = mapper.Map<AccountControl, AccountControlDto>(addingData1.Data);
                return Ok(dto1);
            }
            else
            {
                return BadRequest(addingData1.Errors);
            }
        }

        // DELETE api/<AccountControlController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await accontControlService.DeleteAsync(id);
            if (data.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(data.Errors);
            }
        }
    }
}
