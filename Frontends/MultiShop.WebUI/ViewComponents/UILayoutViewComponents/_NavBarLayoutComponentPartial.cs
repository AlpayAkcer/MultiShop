using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavBarLayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _NavBarLayoutComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
