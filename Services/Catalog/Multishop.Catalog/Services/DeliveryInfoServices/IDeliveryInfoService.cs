using Multishop.Catalog.Dtos.DeliveryInfoDtos;
using Multishop.Catalog.Dtos.ProductDetailDto;

namespace Multishop.Catalog.Services.DeliveryInfoServices
{
    public interface IDeliveryInfoService
    {
        Task<List<ResultDeliveryInfoDto>> GetAllDeliveryInfoAsync();
        Task CreateDeliveryInfoAsync(CreateDeliveryInfoDto createDeliveryInfoDto);
        Task UpdateDeliveryInfoAsync(UpdateDeliveryInfoDto updateDeliveryInfoDto);
        Task DeleteDeliveryInfoAsync(string id);
        Task<GetByIdDeliveryInfoDto> GetByIdDeliveryInfoAsync(string id);
    }
}
