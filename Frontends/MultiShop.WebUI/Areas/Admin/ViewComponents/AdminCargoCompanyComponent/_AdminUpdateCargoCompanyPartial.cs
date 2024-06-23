using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminCargoCompanyComponent
{
    public class _AdminUpdateCargoCompanyPartial : ViewComponent
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public _AdminUpdateCargoCompanyPartial(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(value);
        }
    }
}
