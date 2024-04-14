using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Home = "Anasayfa";
            return View();
        }
    }
}
