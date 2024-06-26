﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ProductDto;
using Multishop.Catalog.Services.ProductServices;

namespace Multishop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productService.GetResultProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("GetFiltersByProduct/{name}/{price}/{color}")]
        public async Task<IActionResult> GetFiltersByProduct(string name = null, decimal? price = null, string color = null)
        {
            var values = await _productService.GetFiltersByProductList(name, price, color);
            return Ok(values);
        }

        [HttpGet("ProductListWithCategoryByCategoryID/{id}")]
        public async Task<IActionResult> ProductListWithCategoryByCategoryID(string id)
        {
            var values = await _productService.GetProductsWithCategoryByCategoryIDAsync(id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Kayıt Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Kayıt Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Kayıt Başarıyla Güncellendi");
        }
    }
}
