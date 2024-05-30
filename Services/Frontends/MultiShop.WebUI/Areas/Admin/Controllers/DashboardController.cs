using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CargoStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.OrderStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly ICargoCustomerStatisticService _cargoCustomerStatisticService;
        private readonly ICargoCompanyStatisticService _cargoCompanyStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IOrderStatisticService _orderStatisticService;

        public DashboardController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService, ICargoCustomerStatisticService cargoCustomerStatisticService, ICargoCompanyStatisticService cargoCompanyStatisticService, ICommentStatisticService commentStatisticService, IOrderStatisticService orderStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
            _cargoCustomerStatisticService = cargoCustomerStatisticService;
            _cargoCompanyStatisticService = cargoCompanyStatisticService;
            _commentStatisticService = commentStatisticService;
            _orderStatisticService = orderStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var brandCount = await _catalogStatisticService.GetBrandCount();
            ViewBag.BrandCount = brandCount;

            var productCount = await _catalogStatisticService.GetProductCount();
            ViewBag.ProductCount = productCount;

            var categoryCount = await _catalogStatisticService.GetCategoryCount();
            ViewBag.CategoryCount = categoryCount;

            var productMaxPriceName = await _catalogStatisticService.GetMaxPriceProductName();
            ViewBag.ProductMaxPriceName = productMaxPriceName;

            var productMinPriceName = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.ProductMinPriceName = productMinPriceName;

            var userTotal = await _userStatisticService.GetUsercount();
            ViewBag.UserTotal = userTotal;

            //var productPriceAvg = await _catalogStatisticService.GetProductAvgPrice();
            //ViewBag.ProductPriceAvg = productPriceAvg;

            var discountCount = await _discountStatisticService.GetDiscountCouponCount();
            ViewBag.DiscountCouponCount = discountCount;

            var messageReadCount = await _messageStatisticService.GetTotalMessageReadCount();
            ViewBag.MessageReadCount = messageReadCount;

            var messageUnReadCount = await _messageStatisticService.GetTotalMessageUnReadCount();
            ViewBag.MessageUnReadCount = messageReadCount;

            var messageTotalCount = await _messageStatisticService.GetTotalMessageCount();
            ViewBag.MessageTotalCount = messageReadCount;

            //Kargo, Kargo Müşterileri Sorguları//
            var cargocustomerCount = await _cargoCustomerStatisticService.GetCargoCustomerCount();
            ViewBag.CargoCustomerCount = cargocustomerCount;

            var companyCount = await _cargoCompanyStatisticService.GetCargoCompanyCount();
            ViewBag.CompanyCount = companyCount;

            //Yorum Sorguları//
            var commentTotalCount = await _commentStatisticService.GetCommentTotalCount();
            ViewBag.CommentTotalCount = commentTotalCount;

            var commentConfirmedCount = await _commentStatisticService.GetCommentConfirmedCount();
            ViewBag.CommentsConfirmedCount = commentConfirmedCount;

            var commentUnConfirmedCount = await _commentStatisticService.GetCommentUnconfirmedCount();
            ViewBag.CommentsUnConfirmedCount = commentUnConfirmedCount;

            ////Sipariş Bilgileri ////

            //var orderTotalCount = await _orderStatisticService.GetOrderTotalCount();
            //ViewBag.OrderTotalCount = orderTotalCount;
            return View();
        }
    }
}
