using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.SliderServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselComponentPartial : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public _CarouselComponentPartial(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sliderService.GetAllSliderAsync();
            return View(values);
        }
    }
}
