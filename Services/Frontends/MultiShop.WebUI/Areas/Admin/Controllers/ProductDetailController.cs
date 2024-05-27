using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDto;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using NToastNotify;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    [Authorize]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;

        public ProductDetailController(IProductDetailService productDetailService, IProductService productService, IToastNotification toastNotification)
        {
            _productDetailService = productDetailService;
            _productService = productService;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ProductDetailViewBagList();
            var values = await _productDetailService.GetAllProductDetailAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateProductDetail")]
        public IActionResult CreateProductDetail()
        {
            ProductList();  //Ürün Listesi
            ProductDetailViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateProductDetail")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createProductDetailDto.ProductId), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "ProductDetail", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteProductDetail/{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
            return RedirectToAction("Index", "ProductDetail", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ProductDetailViewBagList();
            ProductList();
            var values = await _productDetailService.GetByIdProductDetailAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateProductDetailDto.ProductDetailId), new ToastrOptions { Title = "Başarıyla Güncellendi" });
            return RedirectToAction("Index", "ProductDetail", new { Area = "Admin" });
        }

        public async void ProductList()
        {
            #region ProductList
            var values = await _productService.GetAllProductAsync();
            List<SelectListItem> productValue = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ProductId.ToString()
                                                 }).ToList();
            ViewBag.ProductList = productValue;
            #endregion
        }

        void ProductDetailViewBagList()
        {
            ViewBag.V0 = "Ürün Detay İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürün Detay";
        }
    }
}
