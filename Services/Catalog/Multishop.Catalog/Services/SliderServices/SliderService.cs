using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.SliderDtos;
using Multishop.Catalog.Entites;
using Multishop.Catalog.Services.SliderServices;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly IMongoCollection<Slider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<Slider>(_databaseSettings.SliderCollectionName);

            _mapper = mapper;
        }

        public async Task ChangeStatusSlider(string id)
        {
            await _featureSliderCollection.FindAsync(x => x.SliderId == id);
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.SliderId == id);
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            var value = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(value);
        }

        public async Task<GetByIdSliderDto> GetByIdSliderAsync(string id)
        {
            var value = await _featureSliderCollection.Find<Slider>(x => x.SliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSliderDto>(value);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            var value = _mapper.Map<Slider>(updateSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.SliderId == updateSliderDto.SliderId, value);
        }
    }
}
