
using System.Net.Http;

namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;
        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalMessageByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("UserMessage/GetTotalMessageByReceiverId?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
