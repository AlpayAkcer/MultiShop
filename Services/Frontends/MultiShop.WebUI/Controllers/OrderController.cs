using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Home = "Anasayfa";
            ViewBag.Home1 = "Siparişler";
            ViewBag.Home2 = "Sipariş Detay";
            return View();
        }
    }
}
