
using MultiShop.DtoLayer.CatalogDtos.SliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSliderAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task DeleteSliderAsync(string id);
        Task<UpdateSliderDto> GetByIdSliderAsync(string id);
        Task ChangeStatusSlider(string id);
    }
}
