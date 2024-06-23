using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorBrandComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _VendorBrandComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }      
    }
}
