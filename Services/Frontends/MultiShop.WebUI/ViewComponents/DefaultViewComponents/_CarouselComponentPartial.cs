using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SliderDtos;
using Newtonsoft.Json;
using NToastNotify;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarouselComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7050/api/Sliders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
