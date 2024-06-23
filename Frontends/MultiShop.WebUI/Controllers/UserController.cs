using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _userService.GetUserInfo();
            return View(value);
        }

    }
}
