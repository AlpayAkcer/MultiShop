namespace MultiShop.WebUI.Services.StatisticServices.OrderStatisticServices
{
    public class OrderStatisticService : IOrderStatisticService
    {
        private readonly HttpClient _httpClient;
        public OrderStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetOrderTotalCount()
        {
            var responseMessage = await _httpClient.GetAsync("Orderings/GetOrderTotalCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
