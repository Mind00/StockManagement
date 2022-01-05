using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Services.AccSubControl;
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
    public class AccountSubControlController : ControllerBase
    {
        private readonly IAccountSubCtrlService accountSubCtrlService;
        private readonly IMapper mapper;

        public AccountSubControlController(IAccountSubCtrlService _accCtrl, IMapper _mapper)
        {
            accountSubCtrlService = _accCtrl;
            mapper = _mapper;
        }
        // GET: api/<AccountSubControlController>
        [HttpGet]
        public async Task<IEnumerable<AccountSubControlDto>> GetList()
        {
            var data = await accountSubCtrlService.ListAsync();
            var dto = mapper.Map<IEnumerable<AccountSubControl>, IEnumerable<AccountSubControlDto>>(data);
            return dto;
        }

        // GET api/<AccountSubControlController>/5
        [HttpGet("{id}")]
        public async Task<AccountSubControlDto> Get(int id)
        {
            var data = await accountSubCtrlService.GetById(id);
            var dto = mapper.Map<AccountSubControl, AccountSubControlDto>(data.Data);
            return dto;
        }

        // POST api/<AccountSubControlController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountSubControlDto accountSubControlDto)
        {
            var dto = mapper.Map<AccountSubControlDto, AccountSubControl>(accountSubControlDto);
            var result = await accountSubCtrlService.CreateAsync(dto);
            if (result.IsSuccess)
            {
                var resource = mapper.Map<AccountSubControl, AccountSubControlDto>(result.Data);
                return Ok(resource);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        // PUT api/<AccountSubControlController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AccountSubControlDto subControlDto)
        {
            var dto = mapper.Map<AccountSubControlDto, AccountSubControl>(subControlDto);
            var result = await accountSubCtrlService.UpdateAsync(id, dto);
            if (result.IsSuccess)
            {
                var resource = mapper.Map<AccountSubControl, AccountSubControlDto>(result.Data);
                return Ok(resource);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        // DELETE api/<AccountSubControlController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await accountSubCtrlService.DeleteAsync(id);
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
