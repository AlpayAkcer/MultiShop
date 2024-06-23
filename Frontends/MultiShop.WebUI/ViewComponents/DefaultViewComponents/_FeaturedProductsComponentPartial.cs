using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeaturedProductsComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeaturedProductsComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var response = await client.GetAsync("https://localhost:7050/api/Products/ProductListWithCategory");
            var values = await _productService.GetResultProductWithCategoryAsync();
            return View(values);
        }
    }
}
