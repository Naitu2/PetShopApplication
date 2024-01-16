using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Repositories;
using PetShopApplication.Services;
using PetShopApplication.ViewComponents;

namespace PetShopApplication.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IPetShopRepository _repository;
        private AnimalListViewModel _listViewModel;
        public CatalogController(IPetShopRepository repository, IListViewModelService listViewModelService)
        {
            _repository = repository;
            _listViewModel = listViewModelService.GetListViewModelData("Catalog");
        }

        public IActionResult Index()
        {
            var animals = _repository.GetAnimals();
            ViewBag.Categories = _repository.GetCategories().Select(c => c.Name).ToList();

            _listViewModel.Animals = animals;

            return View(_listViewModel);
        }
        [HttpPost]
        public IActionResult ShowCategory(string selectedCategory)
        {
            var animals = _repository.GetAnimals(selectedCategory);

            _listViewModel.Animals = animals;

            return ViewComponent("AnimalList", _listViewModel);
        }

        public IActionResult Details(int animalId)
        {
            return View(_repository.GetAllAnimalInfo(animalId));
        }
    }
}
