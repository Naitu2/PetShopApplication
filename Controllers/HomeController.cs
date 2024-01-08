using Microsoft.AspNetCore.Mvc;

namespace PetShopApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Catalog()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
    }
}
