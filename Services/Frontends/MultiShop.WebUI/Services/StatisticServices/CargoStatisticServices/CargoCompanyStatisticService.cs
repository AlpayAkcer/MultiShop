
namespace MultiShop.WebUI.Services.StatisticServices.CargoStatisticServices
{
    public class CargoCompanyStatisticService : ICargoCompanyStatisticService
    {
        private readonly HttpClient _httpClient;
        public CargoCompanyStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetCargoCompanyCount()
        {
            var responseMessage = await _httpClient.GetAsync("CargoCompanies/GetCargoCompanyCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }

    }
}
