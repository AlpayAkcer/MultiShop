using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using NToastNotify;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly ICategoryService _categoryService;

        public CategoryController(IToastNotification toastNotification, ICategoryService categoryService)
        {
            _toastNotification = toastNotification;
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CategoryViewBagList();

            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            CategoryViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createCategoryDto.Name), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryViewBagList();
            var values = await _categoryService.GetByIdCategoryAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateCategoryDto.Name), new ToastrOptions { Title = "Başarıyla Güncellendi" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        void CategoryViewBagList()
        {
            ViewBag.V0 = "Kategori İşlemleri";
            ViewBag.V1 = "Anasayfa";
            ViewBag.V2 = "Kategoriler";
        }
    }
}
