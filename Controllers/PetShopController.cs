using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Repositories;

namespace PetShopApplication.Controllers
{
    public class PetShopController : Controller
    {
        private IPetShopRepository _repository;
        public PetShopController(IPetShopRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Catalog()
        {
            return View(_repository.GetAnimals());
        }
        public IActionResult Admin()
        {
            return View();
        }
    }
}
