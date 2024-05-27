using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SliderDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CatalogServices.SliderServices;
using NToastNotify;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Slider")]
    [Authorize]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IToastNotification _toastNotification;

        public SliderController(ISliderService sliderService, IToastNotification toastNotification)
        {
            _sliderService = sliderService;
            _toastNotification = toastNotification;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _sliderService.GetAllSliderAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateSlider")]
        public IActionResult CreateSlider()
        {
            SliderViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateSlider")]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            await _sliderService.CreateSliderAsync(createSliderDto);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createSliderDto.Title), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Slider", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteSlider/{id}")]
        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderService.DeleteSliderAsync(id);
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
            return RedirectToAction("Index", "Slider", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateSlider/{id}")]
        public async Task<IActionResult> UpdateSlider(string id)
        {
            SliderViewBagList();
            var values = await _sliderService.GetByIdSliderAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateSlider/{id}")]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            await _sliderService.UpdateSliderAsync(updateSliderDto);
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateSliderDto.Title), new ToastrOptions { Title = "Başarıyla Güncellendi" });
            return RedirectToAction("Index", "Slider", new { Area = "Admin" });
        }

        void SliderViewBagList()
        {
            ViewBag.V0 = "SpecialOffer İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Slider";
        }
    }
}
