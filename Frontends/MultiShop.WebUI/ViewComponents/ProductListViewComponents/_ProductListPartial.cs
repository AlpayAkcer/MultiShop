using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            string categoryId = id;
            var productValues = await _productService.GetProductsWithCategoryByCategoryIDAsync(categoryId);
            return View(productValues);           
        }
    }
}

