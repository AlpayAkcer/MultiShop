namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public interface IMessageStatisticService
    {
        Task<int> GetTotalMessageCount();   //Toplam Gelen Mesaj Sayısı
        Task<int> GetTotalMessageReadCount(); // Okunan mesaj sayısı
        Task<int> GetTotalMessageUnReadCount(); // Okunmayan Mesaj sayısı
    }
}
