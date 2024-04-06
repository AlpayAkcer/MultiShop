using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.Catalog.Dtos.ProductDto;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDto;
using MultiShop.WebUI.ResultMessage;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public ProductDetailController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.V0 = "Ürün Detay İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürün Detay";
            ViewBag.V3 = "Ürün Detay Listesi";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7050/api/ProductDetails/GetProductWithProductDetails");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                List<ResultProductWithProductDetailDto> value = JsonConvert.DeserializeObject<List<ResultProductWithProductDetailDto>>(jsonData);
                return View(value);

            }
            return View();
        }

        [HttpGet]
        [Route("CreateProductDetail")]
        public IActionResult CreateProductDetail()
        {
            ViewBag.V0 = "Ürün Detay İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürün Detay";
            ViewBag.V3 = "Ürün Detay Ekle";

            ProductList();

            return View();
        }

        [HttpPost]
        [Route("CreateProductDetail")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7050/api/ProductDetails", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createProductDetailDto.ProductId), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "ProductDetail", new { Area = "Admin" });
            }
            return View();
        }

        [HttpDelete("{id}")]
        [Route("DeleteProductDetail/{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7050/api/ProductDetails?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
                return RedirectToAction("Index", "ProductDetail", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.V0 = "Marka İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Markalar";
            ViewBag.V3 = "Marka Güncelle";

            ProductList();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7050/api/ProductDetails/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7050/api/ProductDetails", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateProductDetailDto.ProductDetailId), new ToastrOptions { Title = "Başarıyla Güncellendi" });
                return RedirectToAction("Index", "ProductDetail", new { Area = "Admin" });
            }
            return View();
        }

        public async void ProductList()
        {
            #region ProductList
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7050/api/Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            List<SelectListItem> productValue = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ProductId.ToString()
                                                 }).ToList();
            ViewBag.ProductList = productValue;
            #endregion
        }
    }
}
