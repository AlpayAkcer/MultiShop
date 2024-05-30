namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageByReceiverId(string id);
    }
}
