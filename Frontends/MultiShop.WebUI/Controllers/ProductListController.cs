using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CommentDtos;
using MultiShop.WebUI.ResultMessage;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("ProductList/{id}")]
        public IActionResult Index(string id)
        {
            ViewBag.Home = "Anasayfa";
            ViewBag.Home1 = "Ürünler";
            ViewBag.Home2 = "Ürün Listesi";
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.pid = id;
            ViewBag.Home = "Anasayfa";
            ViewBag.Home1 = "Ürünler";
            ViewBag.Home2 = "Ürün Detayı";
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "Test";
            createCommentDto.Rating = 1;
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            //createCommentDto.ProductId = "660ae9485a5a394b399e8d99";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7050/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                //_toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createCategoryDto.Name), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Default");
            }
            return View();

        }
    }
}
