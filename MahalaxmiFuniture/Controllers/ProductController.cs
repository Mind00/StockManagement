using AutoMapper;
using MahalaxmiFuniture.DTOs;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }
        // GET: ProductController
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productList = await _productService.ListAsync();
            var dto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(productList);
            return dto;
        }

        // GET: ProductController/Details/5
        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            var dto = _mapper.Map<Product, ProductDto>(product.Data);
            return dto;
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromBody] ProductDto product)
        {
            var productDto =  _mapper.Map<ProductDto, Product>(product);
            var result = await _productService.SaveAsync(productDto);
            if (result.IsSuccess)
            {
                var resource = _mapper.Map<Product, ProductDto>(result.Data);
                return Ok(resource);
            }
            return BadRequest(result.Message);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [FromBody] ProductDto dto)
        {
            var product = _mapper.Map<ProductDto, Product>(dto);
            var result = await _productService.UpdateAsync(id, product);
            if (result.IsSuccess)
            {
                var resource = _mapper.Map<Product, ProductDto>(result.Data);
                return Ok(resource);
            }
            return BadRequest(result.Message);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return Ok(result.Message);
            }
        }
    }
}
