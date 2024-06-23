using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.ResultMessage;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Contact")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public ContactController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {           
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7050/api/Contacts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateContact")]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateContact")]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:7050/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage(NotifyMessage.ResultTitle.Add(createContactDto.Subject), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Contact", new { Area = "Admin" });
            }
            return View();
        }

        [HttpDelete("{id}")]
        [Route("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:7050/api/Contacts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddErrorToastMessage(NotifyMessage.ResultTitle.Delete(id.ToString()), new ToastrOptions { Title = "Başarıyla Silindi" });
                return RedirectToAction("Index", "Contact", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateContact/{id}")]
        public async Task<IActionResult> UpdateContact(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7050/api/Contacts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateContact/{id}")]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:7050/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddWarningToastMessage(NotifyMessage.ResultTitle.Update(updateContactDto.Subject), new ToastrOptions { Title = "Başarıyla Güncellendi" });
                return RedirectToAction("Index", "Contact", new { Area = "Admin" });
            }
            return View();
        }
    }
}
