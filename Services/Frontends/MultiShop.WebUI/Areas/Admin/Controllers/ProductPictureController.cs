using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductPictureDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CatalogServices.ProductPictureServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductPicture")]
    public class ProductPictureController : Controller
    {
        private readonly IProductPictureService _productPictureService;
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductPictureController(IHttpClientFactory httpClientFactory, IProductPictureService productPictureService, IToastNotification toastNotification, IProductService productService)
        {
            _productPictureService = productPictureService;
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ProductPictureViewBagList();
            var values = await _productPictureService.GetAllProductImageAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateProductPicture")]
        public IActionResult CreateProductPicture()
        {
            ProductPictureViewBagList();
            PictureProductList();
            return View();
        }

        [HttpPost]
        [Route("CreateProductPicture")]
        public async Task<IActionResult> CreateProductPicture(CreateProductPictureDto createProductPictureDto)
        {
            var client = _httpClientFactory.CreateClient();

            foreach (var file in createProductPictureDto.MultiFile)
            {
                if (file.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var jsonData = JsonConvert.SerializeObject(createProductPictureDto);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    createProductPictureDto.PictureUrl = uniqueFileName;

                    var responseMessage = await client.PostAsync("https://localhost:7050/api/ProductPictures", stringContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {

                        _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createProductPictureDto.ProductId), new ToastrOptions { Title = "Başarılı" });
                    }
                }
            }
            return RedirectToAction("Index", "ProductPicture", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteProductPicture/{id}")]
        public async Task<IActionResult> DeleteProductPicture(string id)
        {
            await _productPictureService.DeleteProductImageAsync(id);
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
            return RedirectToAction("Index", "ProductPicture", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateProductPicture/{id}")]
        public async Task<IActionResult> UpdateProductPicture(string id)
        {
            ProductPictureViewBagList();
            PictureProductList();
            var value = await _productPictureService.GetByProductIdProductImageAsync(id);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateProductPicture/{id}")]
        public async Task<IActionResult> UpdateProductPicture(UpdateProductPictureDto updateProductPictureDto)
        {
            await _productPictureService.UpdateProductImageAsync(updateProductPictureDto);
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateProductPictureDto.ProductId), new ToastrOptions { Title = "Başarıyla Güncellendi" });
            return RedirectToAction("Index", "ProductPicture", new { Area = "Admin" });
        }

        public async void PictureProductList()
        {
            #region Product
            var value = await _productService.GetAllProductAsync();
            List<SelectListItem> productValue = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ProductId.ToString()
                                                 }).ToList();
            ViewBag.ProductList = productValue;
            #endregion
        }

        void ProductPictureViewBagList()
        {
            ViewBag.V0 = "Ürün Resimleri İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürün Resimleri";
        }
    }
}
