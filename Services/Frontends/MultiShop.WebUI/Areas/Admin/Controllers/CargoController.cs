using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using NToastNotify;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    [Authorize]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IToastNotification _toastNotification;
        public CargoController(ICargoCompanyService cargoCompanyService, IToastNotification toastNotification)
        {
            _cargoCompanyService = cargoCompanyService;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            CargoCompanyViewBagList();
            var value = await _cargoCompanyService.GetAllCargoCompanyListAsync();
            return View(value);
        }

        [HttpGet]
        [Route("CreateCargoCompany")]
        public IActionResult CreateCompany()
        {
            CargoCompanyViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createCargoCompanyDto.CargoName), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("CargoCompanyList", "Cargo", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteCargo/{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
            return RedirectToAction("CargoCompanyList", "Cargo", new { Area = "Admin" });
        }

        //[HttpGet]
        //[Route("UpdateCargoCompany/{id}")]
        //public async Task<IActionResult> UpdateCargoCompany(int id)
        //{
        //    CargoCompanyViewBagList();
        //    var values = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
        //    return View(values);
        //}

        [HttpPost]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateCargoCompanyDto.CargoName), new ToastrOptions { Title = "Başarıyla Güncellendi" });
            return RedirectToAction("CargoCompanyList", "Cargo", new { Area = "Admin" });
        }

        void CargoCompanyViewBagList()
        {
            ViewBag.V0 = "Kargo Firma İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Kargo Firma";
        }
    }
}
