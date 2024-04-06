using Multishop.Catalog.Dtos.ProductDetailDto;

namespace Multishop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetail);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<List<ResultProductWithProductDetailDto>> GetByProductIdProductDetailAsync(string id);
        Task<List<ResultProductWithProductDetailDto>> GetProductWithProductDetailAsync();
    }
}
