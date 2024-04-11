using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using NToastNotify;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;
        private readonly IToastNotification _toastNotification;

        public SpecialOfferController(ISpecialOfferService specialOfferService, IToastNotification toastNotification)
        {
            _specialOfferService = specialOfferService;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SpecialOfferViewBagList();
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createSpecialOfferDto.Title), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "SpecialOffer", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
            return RedirectToAction("Index", "SpecialOffer", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewBagList();
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateSpecialOfferDto.Title), new ToastrOptions { Title = "Başarıyla Güncellendi" });
            return RedirectToAction("Index", "SpecialOffer", new { Area = "Admin" });
        }

        void SpecialOfferViewBagList()
        {
            ViewBag.V0 = "Special Offer İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Special Offer";
        }
    }
}
