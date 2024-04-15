using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;
        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<PartialViewResult> ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            if (code != null)
            {
                var values = await _discountService.GetDiscountCouponCountRate(code);
                var basketvalue = await _basketService.GetBasket();
                var totalPriceWithTax = basketvalue.TotalPrice + basketvalue.TotalPrice / 100 * 10;
                var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);
                ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

                return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = values, totalNewPriceWithDiscount = totalNewPriceWithDiscount });
            }
            else
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
        }
    }
}


