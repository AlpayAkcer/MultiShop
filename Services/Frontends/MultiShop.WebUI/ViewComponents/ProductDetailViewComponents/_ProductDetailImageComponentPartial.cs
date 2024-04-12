using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductPictureServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageComponentPartial : ViewComponent
    {
        private readonly IProductPictureService _productPictureServices;

        public _ProductDetailImageComponentPartial(IProductPictureService productPictureServices)
        {
            _productPictureServices = productPictureServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productValues = await _productPictureServices.GetByProductIdProductImageAsync(id);
            return View(productValues);
        }
    }
}
