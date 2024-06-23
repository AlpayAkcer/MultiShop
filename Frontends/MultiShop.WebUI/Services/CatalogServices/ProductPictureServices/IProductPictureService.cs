
using MultiShop.DtoLayer.CatalogDtos.ProductPictureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductPictureServices
{
    public interface IProductPictureService
    {
        Task<List<ResultProductPictureDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductPictureDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductPictureDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductPictureDto> GetByIdProductImageAsync(string id);
        //Ürün resmi
        Task<List<GetByIdProductPictureDto>> GetByProductIdProductImageAsync(string id);
        //Ürün resimleri 
    }
}
