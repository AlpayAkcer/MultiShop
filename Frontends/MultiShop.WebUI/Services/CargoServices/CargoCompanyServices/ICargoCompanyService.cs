using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyListAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task DeleteCargoCompanyAsync(int id);
        Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id);
    }
}
