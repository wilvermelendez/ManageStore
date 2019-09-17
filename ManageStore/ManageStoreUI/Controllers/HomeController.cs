using Microsoft.AspNetCore.Mvc;

namespace ManageStoreUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
