using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ProductPictureDto;
using Multishop.Catalog.Services.ProductPictureServices;

namespace Multishop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPicturesController : ControllerBase
    {
        private readonly IProductPictureService _productPictureService;

        public ProductPicturesController(IProductPictureService productPictureService)
        {
            _productPictureService = productPictureService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductPictureList()
        {
            var values = await _productPictureService.GetAllProductPictureAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductPictureByID(string id)
        {
            var values = await _productPictureService.GetByIdProductPictureAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateproductPicture(CreateProductPictureDto createProductPictureDto)
        {
            await _productPictureService.CreateProductPictureAsync(createProductPictureDto);
            return Ok("Kayıt Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteproductPicture(string id)
        {
            await _productPictureService.DeleteProductPictureAsync(id);
            return Ok("Kayıt Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateproductPicture(UpdateProductPictureDto updateProductPictureDto)
        {
            await _productPictureService.UpdateProductPictureAsync(updateProductPictureDto);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpGet("GetPictureByProductID")]
        public async Task<IActionResult> GetPictureByProductID(string id)
        {
            var values = await _productPictureService.GetPictureByProductIDAsync(id);
            return Ok(values);
        }        
    }
}
