using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCustomerDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var value = _cargoCustomerService.TGetAllList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                CustomerAddress = createCargoCustomerDto.CustomerAddress,
                CustomerTitle = createCargoCustomerDto.CustomerTitle,
                CustomerCity = createCargoCustomerDto.CustomerCity,
                CustomerDistrict = createCargoCustomerDto.CustomerDistrict,
                CustomerEmail = createCargoCustomerDto.CustomerEmail,
                CustomerName = createCargoCustomerDto.CustomerName,
                CustomerPhone = createCargoCustomerDto.CustomerPhone,
                CustomerSurname = createCargoCustomerDto.CustomerSurname,
                UserCustomerId = createCargoCustomerDto.UserCustomerId
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo Şirketi Başarıyla Oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Şirketi Başarıyla Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                CustomerTitle = updateCargoCustomerDto.CustomerTitle,
                CustomerAddress = updateCargoCustomerDto.CustomerAddress,
                CustomerCity = updateCargoCustomerDto.CustomerCity,
                CustomerDistrict = updateCargoCustomerDto.CustomerDistrict,
                CustomerEmail = updateCargoCustomerDto.CustomerEmail,
                CustomerName = updateCargoCustomerDto.CustomerName,
                CustomerPhone = updateCargoCustomerDto.CustomerPhone,
                CustomerSurname = updateCargoCustomerDto.CustomerSurname,
                UserCustomerId = updateCargoCustomerDto.UserCustomerId
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo Şirketi Başarıyla Güncellendi.");
        }
    }
}
