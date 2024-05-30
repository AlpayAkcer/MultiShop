using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCompanyDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var value = _cargoCompanyService.TGetAllList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto cargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoName = cargoCompanyDto.CargoName
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla Oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo Şirketi Başarıyla Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto cargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyId = cargoCompanyDto.CargoCompanyId,
                CargoName = cargoCompanyDto.CargoName
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla Güncellendi.");
        }

        [HttpGet("GetCargoCompanyCount")]
        public IActionResult GetCargoCompanyCount()
        {
            var value = _cargoCompanyService.TGetCargoCompanyCount();
            return Ok(value);
        }
    }
}
