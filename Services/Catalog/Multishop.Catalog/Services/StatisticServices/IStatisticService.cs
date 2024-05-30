namespace Multishop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        //Veri olarak ne getirmek istiyorsak o methodları burada tanımlayacağız. 
        //Kaç veriden kaçtane olduğu hangi ürün stok adedi gibi verileri

        // long olmasının sebebi Mongo db de bunları integer yaptığımızda istediğimiz sonucu vermiyor olması.
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
