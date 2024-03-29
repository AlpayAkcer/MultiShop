using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductDto;
using Multishop.Catalog.Dtos.ProductPictureDto;
using Multishop.Catalog.Entites;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductPictureServices
{
    public class ProductPictureService : IProductPictureService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductPicture> _productPictureCollection;
        public ProductPictureService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productPictureCollection = database.GetCollection<ProductPicture>(databaseSettings.ProductPictureCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductPictureAsync(CreateProductPictureDto createProductPicture)
        {
            var value = _mapper.Map<ProductPicture>(createProductPicture);
            await _productPictureCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductPictureAsync(string id)
        {
            await _productPictureCollection.DeleteOneAsync(x => x.ProductId == id);
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

        public async Task UpdateProductPictureAsync(UpdateProductPictureDto updateProductPictureDto)
        {
            var value = _mapper.Map<ProductPicture>(updateProductPictureDto);
            await _productPictureCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductPictureDto.ProductImageId, value);
        }
    }
}
