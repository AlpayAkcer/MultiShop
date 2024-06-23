using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<List<ResultCargoCustomerDto>> GetByCargoCustomerListAsync(string id);
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerAsync(string id);
    }
}
