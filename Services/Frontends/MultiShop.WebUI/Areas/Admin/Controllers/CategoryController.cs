using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IActionResult> Index()
        {
            ViewBag.V0 = "Kategori İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Kategoriler";
            ViewBag.V3 = "Kategori Listesi";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7050/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
