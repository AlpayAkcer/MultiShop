using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.Catalog.Entites;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductPictureDtos;
using MultiShop.WebUI.ResultMessage;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductPicture")]
    public class ProductPictureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public ProductPictureController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.V0 = "Ürün Resimleri İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürün Resimleri";
            ViewBag.V3 = "Ürün Resimleri Listesi";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7050/api/ProductPictures/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultProductPictureDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateProductPicture")]
        public IActionResult CreateProductPicture()
        {
            ViewBag.V0 = "Ürün Resimleri İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürün Resimleri";
            ViewBag.V3 = "Ürün Resim Ekle";

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
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7050/api/ProductPictures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
                return RedirectToAction("Index", "ProductPicture", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateProductPicture/{id}")]
        public async Task<IActionResult> UpdateProductPicture(string id)
        {
            ViewBag.V0 = "Ürün Resimleri İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Ürün Resimleri";
            ViewBag.V3 = "Ürün Resim Güncelle";

            PictureProductList();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7050/api/ProductPictures/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductPictureDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProductPicture/{id}")]
        public async Task<IActionResult> UpdateProductPicture(UpdateProductPictureDto updateProductPictureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductPictureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7050/api/ProductPictures", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateProductPictureDto.ProductId), new ToastrOptions { Title = "Başarıyla Güncellendi" });
                return RedirectToAction("Index", "ProductPicture", new { Area = "Admin" });
            }
            return View();
        }

        public async void PictureProductList()
        {
            #region Product
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
