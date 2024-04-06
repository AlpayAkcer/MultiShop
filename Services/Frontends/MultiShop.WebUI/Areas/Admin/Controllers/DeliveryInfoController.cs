using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.DeliveryInfoDtos;
using MultiShop.WebUI.ResultMessage;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/DeliveryInfo")]
    public class DeliveryInfoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public DeliveryInfoController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.V0 = "DeliveryInfo İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "DeliveryInfo";
            ViewBag.V3 = "DeliveryInfo Listesi";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7050/api/DeliveryInfos");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultDeliveryInfoDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateDeliveryInfo")]
        public IActionResult CreateDeliveryInfo()
        {
            ViewBag.V0 = "DeliveryInfo İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "DeliveryInfo";
            ViewBag.V3 = "DeliveryInfo Ekle";
            return View();
        }

        [HttpPost]
        [Route("CreateDeliveryInfo")]
        public async Task<IActionResult> CreateDeliveryInfo(CreateDeliveryInfoDto createDeliveryInfoDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDeliveryInfoDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7050/api/DeliveryInfos", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createDeliveryInfoDto.Title), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "DeliveryInfo", new { Area = "Admin" });
            }
            return View();
        }

        [HttpDelete("{id}")]
        [Route("DeleteDeliveryInfo/{id}")]
        public async Task<IActionResult> DeleteDeliveryInfo(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7050/api/DeliveryInfos?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
                return RedirectToAction("Index", "DeliveryInfo", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateDeliveryInfo/{id}")]
        public async Task<IActionResult> UpdateDeliveryInfo(string id)
        {
            ViewBag.V0 = "DeliveryInfo İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "DeliveryInfo";
            ViewBag.V3 = "DeliveryInfo Güncelle";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7050/api/DeliveryInfos/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateDeliveryInfoDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateDeliveryInfo/{id}")]
        public async Task<IActionResult> UpdateDeliveryInfo(UpdateDeliveryInfoDto updateDeliveryInfoDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDeliveryInfoDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7050/api/DeliveryInfos", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateDeliveryInfoDto.Title), new ToastrOptions { Title = "Başarıyla Güncellendi" });
                return RedirectToAction("Index", "DeliveryInfo", new { Area = "Admin" });
            }
            return View();
        }
    }
}
