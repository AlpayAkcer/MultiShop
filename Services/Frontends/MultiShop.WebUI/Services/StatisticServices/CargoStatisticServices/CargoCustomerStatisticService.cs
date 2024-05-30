namespace MultiShop.WebUI.Services.StatisticServices.CargoStatisticServices
{
    public class CargoCustomerStatisticService : ICargoCustomerStatisticService
    {
        private readonly HttpClient _httpClient;
        public CargoCustomerStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetCargoCustomerCount()
        {
            var responseMessage = await _httpClient.GetAsync("CargoCustomers/GetCargoCustomerCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
