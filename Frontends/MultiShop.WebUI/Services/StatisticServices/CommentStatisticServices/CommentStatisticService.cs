
namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;
        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetCommentConfirmedCount()
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetCommentConfirmedCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetCommentTotalCount()
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetCommentTotalCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetCommentUnconfirmedCount()
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetCommentUnconfirmedCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
