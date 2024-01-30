using Microsoft.AspNetCore.Mvc;

namespace PetShopApplication.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return Content("There was an unexpected error :( Please contact our support: maksimkorolev3600@gmail.com");
        }
    }
}
