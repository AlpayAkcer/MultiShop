using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using NToastNotify;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    [Authorize]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;
        private readonly IToastNotification _toastNotification;

        public OfferDiscountController(IOfferDiscountService offerDiscountService, IToastNotification toastNotification)
        {
            _offerDiscountService = offerDiscountService;
            _toastNotification = toastNotification;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createOfferDiscountDto.Title), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "OfferDiscount", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
            return RedirectToAction("Index", "OfferDiscount", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateOfferDiscountDto.Title), new ToastrOptions { Title = "Başarıyla Güncellendi" });
            return RedirectToAction("Index", "OfferDiscount", new { Area = "Admin" });
        }      
    }
}
