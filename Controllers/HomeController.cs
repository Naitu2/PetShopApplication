using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Repositories;

namespace PetShopApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetShopRepository _repository;
        public HomeController(IPetShopRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetTwoTopAnimals());
        }
    }
}
