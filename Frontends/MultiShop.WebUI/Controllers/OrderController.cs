using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Home = "Anasayfa";
            ViewBag.Home1 = "Siparişler";
            ViewBag.Home2 = "Sipariş Detay";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            ViewBag.Home = "Anasayfa";
            ViewBag.Home1 = "Siparişler";
            ViewBag.Home2 = "Sipariş Detay";

            //Aktif giriş yapmış kullanıcının adını ve id bilgileri alma
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;
            if (createOrderAddressDto.Description == null)
            {
                createOrderAddressDto.Description = "Not Eklenmemiş";
            }
            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);
            return RedirectToAction("Index", "Payment");
        }
    }
}
