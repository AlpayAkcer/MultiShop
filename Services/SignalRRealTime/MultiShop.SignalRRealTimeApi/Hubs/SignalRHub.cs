using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        //Real Time olarak neler yapmak istediğimizi yazacağız fakat bunları da bir service bağlamak gerekiyor
        // Servise bağlamak için api yazmamız gerekecek. API'ye UI tarafından consume edeceğiz.
        //

        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageService _signalRMessageService;

        public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {
            _signalRCommentService = signalRCommentService;
            _signalRMessageService = signalRMessageService;
        }

        public async Task SendStatisticCount(string id)
        {
            var getTotalCommentCount = _signalRCommentService.GetCommentTotalCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

            var getTotalMessageCount = _signalRMessageService.GetTotalMessageByReceiverId(id);
            await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
        }
    }
}
