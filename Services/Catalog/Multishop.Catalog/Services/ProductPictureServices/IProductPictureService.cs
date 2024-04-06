using Multishop.Catalog.Dtos.ProductDto;
using Multishop.Catalog.Dtos.ProductPictureDto;

namespace Multishop.Catalog.Services.ProductPictureServices
{
    public interface IProductPictureService
    {
        Task<List<ResultProductPictureDto>> GetAllProductPictureAsync();
        Task CreateProductPictureAsync(CreateProductPictureDto createProductPicture);
        Task UpdateProductPictureAsync(UpdateProductPictureDto updateProductPictureDto);
        Task DeleteProductPictureAsync(string id);
        Task<GetByIdProductPictureDto> GetByIdProductPictureAsync(string id);
        Task<List<ResultProductPictureDto>> GetPictureByProductIDAsync(string productid);
    }
}
