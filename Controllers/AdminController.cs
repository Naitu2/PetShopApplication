using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;
using PetShopApplication.Repositories;
using PetShopApplication.Services;
using PetShopApplication.ViewComponents;

namespace PetShopApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPetShopRepository _repository;
        private AnimalListViewModel _listViewModel;
        private string _selectedCategory = "All Categories";
        public AdminController(IPetShopRepository repository, IListViewModelService listViewModelService)
        {
            _repository = repository;
            _listViewModel = listViewModelService.GetListViewModelData("Admin");
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
            _selectedCategory = selectedCategory;
            var animals = _repository.GetAnimals(_selectedCategory);
            _listViewModel.Animals = animals;

            return ViewComponent("AnimalList", _listViewModel);
        }

        [HttpPost]
        public IActionResult DeleteAnimal(int animalId)
        {
            _repository.DeleteAnimal(animalId);

            var animals = _repository.GetAnimals(_selectedCategory);

            _listViewModel.Animals = animals;

            return ViewComponent("AnimalList", _listViewModel);
        }

        public IActionResult UpdateAnimal(int animalId)
        {
            ViewBag.Categories = _repository.GetCategories();

            return View(_repository.GetAnimalWithCategory(animalId));
        }

        [HttpPost]
        public IActionResult SubmitAnimal(Animal updatedAnimal)
        {
            if (ModelState.IsValid)
            {
                if (_repository.AnimalExists(updatedAnimal.Id))
                {
                    _repository.UpdateAnimal(updatedAnimal);
                }
                else
                {
                    _repository.InsertAnimal(updatedAnimal);
                }

                return View("Index");
            }
            else
            {
                return View("UpdateAnimal");
            }
        }
    }
}
