using MultiShop.DtoLayer.CatalogDtos.ProductPictureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductPictureServices
{
    public class ProductPictureService : IProductPictureService
    {
        private readonly HttpClient _httpClient;
        public ProductPictureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductImageAsync(CreateProductPictureDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductPictureDto>("productpictures", createProductImageDto);
        }
        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productpictures?id=" + id);
        }
        public async Task<List<ResultProductPictureDto>> GetAllProductImageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productpictures");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductPictureDto>>(jsonData);
            return values;
        }
        public async Task UpdateProductImageAsync(UpdateProductPictureDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductPictureDto>("productpictures", updateProductImageDto);
        }
        public async Task<GetByIdProductPictureDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productpictures/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductPictureDto>();
            return values;
        }

        public async Task<List<GetByIdProductPictureDto>> GetByProductIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productpictures/GetPictureByProductID/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetByIdProductPictureDto>>(jsonData);
            return values;
        }
    }
}
