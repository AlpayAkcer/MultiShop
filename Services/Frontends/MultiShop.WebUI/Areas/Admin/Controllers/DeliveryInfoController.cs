using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.DeliveryInfoDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CatalogServices.DeliveryInfoServices;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/DeliveryInfo")]
    [Authorize]
    public class DeliveryInfoController : Controller
    {
        private readonly IDeliveryInfoService _deliveryInfoService;
        private readonly IToastNotification _toastNotification;

        public DeliveryInfoController(IDeliveryInfoService deliveryInfoService, IToastNotification toastNotification)
        {
            _deliveryInfoService = deliveryInfoService;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _deliveryInfoService.GetAllDeliveryInfoAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateDeliveryInfo")]
        public IActionResult CreateDeliveryInfo()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateDeliveryInfo")]
        public async Task<IActionResult> CreateDeliveryInfo(CreateDeliveryInfoDto createDeliveryInfoDto)
        {
            await _deliveryInfoService.CreateDeliveryInfoAsync(createDeliveryInfoDto);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createDeliveryInfoDto.Title), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "DeliveryInfo", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteDeliveryInfo/{id}")]
        public async Task<IActionResult> DeleteDeliveryInfo(string id)
        {
            await _deliveryInfoService.DeleteDeliveryInfoAsync(id);
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
            return RedirectToAction("Index", "DeliveryInfo", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateDeliveryInfo/{id}")]
        public async Task<IActionResult> UpdateDeliveryInfo(string id)
        {
            var value = await _deliveryInfoService.GetByIdDeliveryInfoAsync(id);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateDeliveryInfo/{id}")]
        public async Task<IActionResult> UpdateDeliveryInfo(UpdateDeliveryInfoDto updateDeliveryInfoDto)
        {
            await _deliveryInfoService.UpdateDeliveryInfoAsync(updateDeliveryInfoDto);
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateDeliveryInfoDto.Title), new ToastrOptions { Title = "Başarıyla Güncellendi" });
            return RedirectToAction("Index", "DeliveryInfo", new { Area = "Admin" });

        }
    }
}
