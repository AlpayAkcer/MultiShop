using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscount;

        public _OfferComponentPartial(IOfferDiscountService offerDiscount)
        {
            _offerDiscount = offerDiscount;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscount.GetAllOfferDiscountAsync();
            return View(values);
        }
    }
}
