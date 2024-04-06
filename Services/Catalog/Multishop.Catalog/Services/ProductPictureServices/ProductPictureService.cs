using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductDto;
using Multishop.Catalog.Dtos.ProductPictureDto;
using Multishop.Catalog.Entites;
using Multishop.Catalog.Settings;
using Microsoft.AspNetCore.Hosting;

namespace Multishop.Catalog.Services.ProductPictureServices
{
    public class ProductPictureService : IProductPictureService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<ProductPicture> _productPictureCollection;
        public ProductPictureService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productPictureCollection = database.GetCollection<ProductPicture>(databaseSettings.ProductPictureCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductPictureAsync(CreateProductPictureDto createProductPicture)
        {
            var value = _mapper.Map<ProductPicture>(createProductPicture);
            await _productPictureCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductPictureAsync(string id)
        {
            await _productPictureCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductPictureDto>> GetAllProductPictureAsync()
        {
            var value = await _productPictureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductPictureDto>>(value);
        }

        public async Task<GetByIdProductPictureDto> GetByIdProductPictureAsync(string id)
        {
            var value = await _productPictureCollection.Find<ProductPicture>(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductPictureDto>(value);
        }

        public async Task<List<ResultProductPictureDto>> GetPictureByProductIDAsync(string productid)
        {
            var value = await _productPictureCollection.Find(x => x.ProductId == productid).ToListAsync();
            foreach (var item in value)
            {
                item.Product = await _productCollection.Find<Product>(x => x.ProductId == item.ProductId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductPictureDto>>(value);
        }        

        public async Task UpdateProductPictureAsync(UpdateProductPictureDto updateProductPictureDto)
        {
            var value = _mapper.Map<ProductPicture>(updateProductPictureDto);
            await _productPictureCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductPictureDto.ProductImageId, value);
        }
    }
}
