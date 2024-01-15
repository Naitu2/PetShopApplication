using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Repositories;

namespace PetShopApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPetShopRepository _repository;
        public AdminController(IPetShopRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _repository.GetCategories().Select(c => c.Name).ToList();
            return View(_repository.GetAnimals());
        }
    }
}
