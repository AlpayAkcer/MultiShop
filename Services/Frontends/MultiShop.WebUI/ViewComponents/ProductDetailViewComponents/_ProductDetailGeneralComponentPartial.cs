using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailGeneralComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDetailGeneralComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productValues = await _productService.GetByIdProductAsync(id);
            return View(productValues);
        }
    }
}
