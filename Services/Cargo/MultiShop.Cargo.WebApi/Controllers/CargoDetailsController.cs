using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoDetailDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var value = _cargoDetailService.TGetAllList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo Şirketi Başarıyla Oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Şirketi Başarıyla Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo Şirketi Başarıyla Güncellendi.");
        }
    }
}
