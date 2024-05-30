
using System.Net.Http;

namespace MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;
        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetCommentTotalCount()
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetCommentTotalCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
