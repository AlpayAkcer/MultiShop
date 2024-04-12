using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _BreadcrumbUrlLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.Home = "Anasayfa";
            ViewBag.Home1 = "Ürünler";
            ViewBag.Home2 = "Ürün Listesi";
            return View();
        }
    }
}
