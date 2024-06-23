using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using MultiShop.WebUI.ResultMessage;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public RegisterController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createRegisterDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createRegisterDto.FirstName + " " + createRegisterDto.Surname), new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}
