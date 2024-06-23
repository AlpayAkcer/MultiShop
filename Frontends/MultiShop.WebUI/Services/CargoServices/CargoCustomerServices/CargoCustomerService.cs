using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;
using MultiShop.DtoLayer.CatalogDtos.CommentDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        //Kullanıcının kargo adres bilgilerini alacağımızmethod.
        private readonly HttpClient _httpClient;
        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCargoCustomerDto>> GetByCargoCustomerListAsync(string id)
        {
            var response = await _httpClient.GetAsync("cargocustomers/GetCargoCustomerListById?id=" + id);
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultCargoCustomerDto>>(jsonData);
            return value;
        }

        public async Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("cargocustomers/GetCargoCustomerById?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByIdDto>();
            return values;
        }
    }
}
