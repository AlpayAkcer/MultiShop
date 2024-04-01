using Multishop.Catalog.Dtos.SliderDtos;

namespace Multishop.Catalog.Services.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSliderAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task DeleteSliderAsync(string id);
        Task<GetByIdSliderDto> GetByIdSliderAsync(string id);
        Task ChangeStatusSlider(string id);
    }
}
