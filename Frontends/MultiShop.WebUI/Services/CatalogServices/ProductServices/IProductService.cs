﻿using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetResultProductWithCategoryAsync();
        Task CreateProductAsync(CreateProductDto createProduct);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<UpdateProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductDto>> GetFiltersByProductList(string name = null, decimal? price = null, string color = null);
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIDAsync(string categoryid);
    }
}
