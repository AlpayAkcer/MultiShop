using MultiShop.DtoLayer.CatalogDtos.SliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly HttpClient _httpClient;

        public SliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task ChangeStatusSlider(string id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSliderDto>("sliders", createSliderDto);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("sliders?id=" + id);
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("sliders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
            return values;
        }

        public async Task<UpdateSliderDto> GetByIdSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("sliders/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateSliderDto>();
            return values;
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSliderDto>("sliders", updateSliderDto);
        }
    }
}
