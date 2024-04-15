using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using NToastNotify;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IToastNotification _toastNotification;

        public ShoppingCartController(IProductService productService, IBasketService basketService, IToastNotification toastNotification)
        {
            _productService = productService;
            _basketService = basketService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

            ViewBag.Home = "Ana Sayfa";
            ViewBag.Home1 = "Ürünler";
            ViewBag.Home2 = "Sepetim";

            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice.ToString("C");
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
            var tax = values.TotalPrice / 100 * 10;
            ViewBag.totalPriceWithTax = totalPriceWithTax.ToString("C");
            ViewBag.tax = tax.ToString("C");


            var discountTotal = values.TotalPrice - totalNewPriceWithDiscount;
            ViewBag.DiscountTotal = discountTotal.ToString("C");
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var values = await _productService.GetByIdProductAsync(productId);

            var items = new BasketItemDto
            {
                ProductId = productId,
                Price = values.Price,
                ProductName = values.Name,
                PictureUrl = values.PictureUrl,
                Quantity = 1
            };

            await _basketService.AddBasketItem(items);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(items.ProductName),
                new ToastrOptions { Title = "Ürün Sepetinize Eklenmiştir " });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            var values = await _basketService.RemoveBasketItem(productId);
            return RedirectToAction("Index");
        }
    }
}
