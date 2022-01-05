using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Services.CategoryServices;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICatergoryService _catergoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICatergoryService catergoryService, IMapper mapper)
        {
            _catergoryService = catergoryService;
            _mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await _catergoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>((IEnumerable<Category>)categories);
            return resources;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<CategoryDto> GetCategoryItem(int id)
        {
            var categoryItem = await _catergoryService.GetCategoryById(id);
            var resource = _mapper.Map<Category, CategoryDto>(categoryItem.Data);
            return resource;
        }


        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);
            var result = await _catergoryService.SaveAsync(category);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var noticeResource = _mapper.Map<Category, CategoryDto>(result.Data);
            return Ok(noticeResource);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);
            var result = await _catergoryService.UpdateAsync(id,category);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            var updatedCategory = _mapper.Map<Category, CategoryDto>(result.Data);
            return Ok(updatedCategory);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _catergoryService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
