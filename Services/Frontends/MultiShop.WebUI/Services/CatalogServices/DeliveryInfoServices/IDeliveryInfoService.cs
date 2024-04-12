using MultiShop.DtoLayer.CatalogDtos.DeliveryInfoDtos;

namespace MultiShop.WebUI.Services.CatalogServices.DeliveryInfoServices
{
    public interface IDeliveryInfoService
    {
        Task<List<ResultDeliveryInfoDto>> GetAllDeliveryInfoAsync();
        Task CreateDeliveryInfoAsync(CreateDeliveryInfoDto createDeliveryInfoDto);
        Task UpdateDeliveryInfoAsync(UpdateDeliveryInfoDto updateDeliveryInfoDto);
        Task DeleteDeliveryInfoAsync(string id);
        Task<UpdateDeliveryInfoDto> GetByIdDeliveryInfoAsync(string id);
    }
}
