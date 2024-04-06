using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.DeliveryInfoDtos;
using Multishop.Catalog.Services.DeliveryInfoServices;


namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DeliveryInfosController : ControllerBase
    {
        private readonly IDeliveryInfoService _deliveryInfoService;

        public DeliveryInfosController(IDeliveryInfoService deliveryInfoService)
        {
            _deliveryInfoService = deliveryInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> DeliveryInfoList()
        {
            var values = await _deliveryInfoService.GetAllDeliveryInfoAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryInfoById(string id)
        {
            var values = await _deliveryInfoService.GetByIdDeliveryInfoAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeliveryInfo(CreateDeliveryInfoDto createDeliveryInfoDto)
        {
            await _deliveryInfoService.CreateDeliveryInfoAsync(createDeliveryInfoDto);
            return Ok("Kayıt Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureDeliveryInfo(string id)
        {
            await _deliveryInfoService.DeleteDeliveryInfoAsync(id);
            return Ok("Kayıt Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureDeliveryInfo(UpdateDeliveryInfoDto updateFeatureDeliveryInfoDto)
        {
            await _deliveryInfoService.UpdateDeliveryInfoAsync(updateFeatureDeliveryInfoDto);
            return Ok("Kayıt Başarıyla Güncellendi");
        }
    }
}
