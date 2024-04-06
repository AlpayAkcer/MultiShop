using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SliderDtos;
using MultiShop.WebUI.ResultMessage;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Slider")]
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public SliderController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.V0 = "SpecialOffer İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Slider";
            ViewBag.V3 = "Slider Listesi";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7050/api/Sliders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateSlider")]
        public IActionResult CreateSlider()
        {
            ViewBag.V0 = "Slider İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Slider";
            ViewBag.V3 = "Slider Ekle";

            return View();
        }

        [HttpPost]
        [Route("CreateSlider")]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            createSliderDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7050/api/Sliders", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createSliderDto.Title), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Slider", new { Area = "Admin" });
            }
            return View();
        }

        [HttpDelete("{id}")]
        [Route("DeleteSlider/{id}")]
        public async Task<IActionResult> DeleteSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7050/api/Sliders?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
                return RedirectToAction("Index", "Slider", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateSlider/{id}")]
        public async Task<IActionResult> UpdateSlider(string id)
        {
            ViewBag.V0 = "Slider İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Slider";
            ViewBag.V3 = "Slider Güncelle";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7050/api/Sliders/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateSlider/{id}")]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7050/api/Sliders", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateSliderDto.Title), new ToastrOptions { Title = "Başarıyla Güncellendi" });
                return RedirectToAction("Index", "Slider", new { Area = "Admin" });
            }
            return View();
        }
    }
}
