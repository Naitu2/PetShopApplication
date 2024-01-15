using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Repositories;

namespace PetShopApplication.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IPetShopRepository _repository;
        public CatalogController(IPetShopRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _repository.GetCategories().Select(c => c.Name).ToList();
            return View(_repository.GetAnimals());
        }

        [HttpPost]
        public IActionResult ShowCategory(string selectedCategory)
        {
            var animals = _repository.GetAnimals(selectedCategory);

            return ViewComponent("AnimalList", animals);
        }
        public IActionResult Details(int animalId)
        {
            return View(_repository.GetAllAnimalInfo(animalId));
        }
    }
}
