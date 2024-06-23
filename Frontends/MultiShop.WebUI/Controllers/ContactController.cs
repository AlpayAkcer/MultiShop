using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.ResultMessage;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IToastNotification _toastNotification;

        public ContactController(IContactService contactService, IToastNotification toastNotification)
        {
            _contactService = contactService;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Home = "Anasayfa";
            ViewBag.Home1 = "İletişim";
            ViewBag.Home2 = "Bize Ulaşın";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;

            await _contactService.CreateContactAsync(createContactDto);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createContactDto.Subject), new ToastrOptions { Title = "Mesajınız Başarılı Bir Şekilde Gönderilmiştir. " });
            return RedirectToAction("Index", "Default");
        }
    }
}
