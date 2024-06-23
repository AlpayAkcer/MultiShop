using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _BreadcrumbUrlLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {            
            return View();
        }
    }
}
