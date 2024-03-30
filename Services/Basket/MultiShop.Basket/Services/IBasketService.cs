using MultiShop.Basket.Dtos.BasketDto;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
    }
}
