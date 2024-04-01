using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.ResultMessage;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public ProductController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.V0 = "Ürün İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürünler";
            ViewBag.V3 = "Ürün Listesi";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7050/api/Products/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.V0 = "Ürün İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürünler";
            ViewBag.V3 = "Yeni Ürün Ekle";

            ProductCategoryList();

            return View();
        }



        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7050/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createProductDto.Name), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            return View();
        }

        [HttpDelete("{id}")]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7050/api/Products?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.V0 = "Ürün İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürünler";
            ViewBag.V3 = "Ürün Güncelle";

            ProductCategoryList();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7050/api/Products/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7050/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateProductDto.Name), new ToastrOptions { Title = "Başarıyla Güncellendi" });
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            return View();
        }

        public async void ProductCategoryList()
        {
            #region CategoryList
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7050/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValue = (from x in value
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.CategoryList = categoryValue;
            #endregion
        }
    }
}
