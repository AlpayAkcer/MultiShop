using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IToastNotification _toastNotification;

        public BrandController(IBrandService brandService, IToastNotification toastNotification)
        {
            _brandService = brandService;
            _toastNotification = toastNotification;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            BrandViewBagList();
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            BrandViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createBrandDto.BrandName), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Brand", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
            return RedirectToAction("Index", "Brand", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            BrandViewBagList();
            var values = await _brandService.GetByIdBrandAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateBrandDto.BrandName), new ToastrOptions { Title = "Başarıyla Güncellendi" });
            return RedirectToAction("Index", "Brand", new { Area = "Admin" });
        }

        void BrandViewBagList()
        {
            ViewBag.V0 = "Marka İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Markalar";
        }
    }
}
