using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.Interfaces;
using NToastNotify;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IToastNotification toastNotification, IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _toastNotification = toastNotification;
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            return View();
        }

        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.Username = "AlpayAkcer";
            signInDto.Password = "4675190Aa**";
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Deneme", "Test");
        }
    }
}
