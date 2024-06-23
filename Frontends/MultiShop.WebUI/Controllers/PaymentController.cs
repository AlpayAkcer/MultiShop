using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Home = "Ana Sayfa";
            ViewBag.Home1 = "Siparişler";
            ViewBag.Home2 = "Ödeme İşlemi";
            return View();
        }
    }
}
