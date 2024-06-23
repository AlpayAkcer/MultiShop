using MultiShop.DtoLayer.CatalogDtos.DeliveryInfoDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.DeliveryInfoServices
{
    public class DeliveryInfoService : IDeliveryInfoService
    {
        private readonly HttpClient _httpClient;
        public DeliveryInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateDeliveryInfoAsync(CreateDeliveryInfoDto createDeliveryInfoDto)
        {
            await _httpClient.PostAsJsonAsync<CreateDeliveryInfoDto>("deliveryinfos", createDeliveryInfoDto);
        }

        public async Task DeleteDeliveryInfoAsync(string id)
        {
            await _httpClient.DeleteAsync("deliveryinfos?id=" + id);
        }

        public async Task<List<ResultDeliveryInfoDto>> GetAllDeliveryInfoAsync()
        {
            var responseMessage = await _httpClient.GetAsync("deliveryinfos");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDeliveryInfoDto>>(jsonData);
            return values;
        }

        public async Task<UpdateDeliveryInfoDto> GetByIdDeliveryInfoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("deliveryinfos/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateDeliveryInfoDto>();
            return values;
        }

        public async Task UpdateDeliveryInfoAsync(UpdateDeliveryInfoDto updateDeliveryInfoDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateDeliveryInfoDto>("deliveryinfos", updateDeliveryInfoDto);
        }
    }
}
