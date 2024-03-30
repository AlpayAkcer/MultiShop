using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var value = _cargoOperationService.TGetAllList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto cargoCompanyOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = cargoCompanyOperationDto.Barcode,
                Description = cargoCompanyOperationDto.Description,
                OperationDate = DateTime.Now
            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo Operasyon Başarıyla Oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Operasyon Başarıyla Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto cargoCompanyOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = cargoCompanyOperationDto.Barcode,
                Description = cargoCompanyOperationDto.Description,
                OperationDate = DateTime.Now,
                CargoOperationId = cargoCompanyOperationDto.CargoOperationId
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo Operasyon Başarıyla Güncellendi.");
        }
    }
}