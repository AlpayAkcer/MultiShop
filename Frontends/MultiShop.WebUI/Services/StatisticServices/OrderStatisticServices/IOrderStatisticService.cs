namespace MultiShop.WebUI.Services.StatisticServices.OrderStatisticServices
{
    public interface IOrderStatisticService
    {
        Task<int> GetOrderTotalCount();
    }
}
