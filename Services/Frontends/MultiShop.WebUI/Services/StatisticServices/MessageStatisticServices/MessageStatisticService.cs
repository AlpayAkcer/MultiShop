
namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;
        public MessageStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalMessageCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserMessage/GetTotalMessageCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetTotalMessageReadCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserMessage/GetTotalMessageReadCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetTotalMessageUnReadCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserMessage/GetTotalMessageUnReadCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
