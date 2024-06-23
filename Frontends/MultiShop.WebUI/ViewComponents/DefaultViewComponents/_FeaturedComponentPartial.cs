using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.DeliveryInfoServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeaturedComponentPartial : ViewComponent
    {
        private readonly IDeliveryInfoService _deliveryInfoService;

        public _FeaturedComponentPartial(IDeliveryInfoService deliveryInfoService)
        {
            _deliveryInfoService = deliveryInfoService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _deliveryInfoService.GetAllDeliveryInfoAsync();
            return View(values);
        }
    }
}
