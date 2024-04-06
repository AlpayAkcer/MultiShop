using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.DeliveryInfoDtos;
using Multishop.Catalog.Entites;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.DeliveryInfoServices
{
    public class DeliveryInfoService : IDeliveryInfoService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<DeliveryInfo> _deliveryInfoCollection;

        public DeliveryInfoService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _deliveryInfoCollection = database.GetCollection<DeliveryInfo>(_databaseSettings.DeliveryInfoCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDeliveryInfoAsync(CreateDeliveryInfoDto createDeliveryInfoDto)
        {
            var value = _mapper.Map<DeliveryInfo>(createDeliveryInfoDto);
            await _deliveryInfoCollection.InsertOneAsync(value);
        }

        public async Task DeleteDeliveryInfoAsync(string id)
        {
            await _deliveryInfoCollection.DeleteOneAsync(x => x.DeliveryInfoId == id);
        }

        public async Task<List<ResultDeliveryInfoDto>> GetAllDeliveryInfoAsync()
        {
            var value = await _deliveryInfoCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDeliveryInfoDto>>(value);
        }

        public async Task<GetByIdDeliveryInfoDto> GetByIdDeliveryInfoAsync(string id)
        {
            var value = await _deliveryInfoCollection.Find<DeliveryInfo>(x => x.DeliveryInfoId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDeliveryInfoDto>(value);
        }

        public async Task UpdateDeliveryInfoAsync(UpdateDeliveryInfoDto updateDeliveryInfoDto)
        {
            var value = _mapper.Map<DeliveryInfo>(updateDeliveryInfoDto);
            await _deliveryInfoCollection.FindOneAndReplaceAsync(x => x.DeliveryInfoId == updateDeliveryInfoDto.DeliveryInfoId, value);
        }
    }
}
