using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.CategoryDto;
using Multishop.Catalog.Dtos.ProductDetailDto;
using Multishop.Catalog.Entites;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        public readonly IMongoCollection<Product> _productCollection;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetail)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetail);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var value = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(value);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _productDetailCollection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }
        public async Task<List<ResultProductWithProductDetailDto>> GetByProductIdProductDetailAsync(string id)
        {
            var value = await _productDetailCollection.Find(x => x.ProductId == id).ToListAsync();
            foreach (var item in value)
            {
                item.Product = await _productCollection.Find<Product>(x => x.ProductId == item.ProductId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithProductDetailDto>>(value);
        }
        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, value);
        }

        public async Task<List<ResultProductWithProductDetailDto>> GetProductWithProductDetailAsync()
        {
            var value = await _productDetailCollection.Find(x => true).ToListAsync();
            foreach (var item in value)
            {
                item.Product = await _productCollection.Find<Product>(x => x.ProductId == item.ProductId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithProductDetailDto>>(value);

        }
    }
}
