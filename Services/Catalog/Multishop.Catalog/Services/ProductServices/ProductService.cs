﻿using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductDto;
using Multishop.Catalog.Entites;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProduct)
        {
            var value = _mapper.Map<Product>(createProduct);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var value = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(value);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        //Filter için farklı bir dto da kullanılabilir, ürün özelliklerinin de içerisinde olduğu bir dto olabilir. denemek lazım
        public async Task<List<ResultProductDto>> GetFiltersByProductList(string name = null, decimal? price = null, string color = null)
        {
            var value = await _productCollection.Find(x => true).ToListAsync();
            if (name != null)
            {
                value = value.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            if (price != null)
            {
                value = value.Where(x => x.Price.ToString().Contains(price.ToString())).ToList();
            }
            if (color != null)
            {
                value = value.Where(x => x.Category.Name.ToLower().Contains(color.ToLower())).ToList();
            }
            return _mapper.Map<List<ResultProductDto>>(value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIDAsync(string categoryid)
        {
            var value = await _productCollection.Find(x => x.CategoryId == categoryid).ToListAsync();
            foreach (var item in value)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetResultProductWithCategoryAsync()
        {
            var value = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in value)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
        }
    }
}
