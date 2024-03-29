﻿using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;
using PetShopApplication.Repositories;
using PetShopApplication.Services;
using PetShopApplication.ViewComponents;

namespace PetShopApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPetShopRepository _repository;
        private readonly IWebHostEnvironment _environment;
        private AnimalListViewModel _listViewModel;
        public AdminController(IPetShopRepository repository, IListViewModelService listViewModelService, IWebHostEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
            _listViewModel = listViewModelService.GetListViewModelData("Admin");
        }

        public IActionResult Index()
        {
            var selectedCategory = HttpContext.Request.Query["SelectedCategory"];
            var animals = _repository.GetAnimals(selectedCategory);
            ViewBag.Categories = _repository.GetCategories().Select(c => c.Name).ToList();

            _listViewModel.Animals = animals;

            return View(_listViewModel);
        }

        [HttpPost]
        public void DeleteAnimal(int animalId)
        {
            _repository.DeleteAnimal(animalId);
        }

        public IActionResult UpdateAnimal(int animalId)
        {
            ViewBag.Categories = _repository.GetCategories();

            return View(_repository.GetAnimalWithCategory(animalId));
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(Animal updatedAnimal)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _repository.GetCategories();
                return View("UpdateAnimal");
            }

            if (updatedAnimal.UploadedImage != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(updatedAnimal.UploadedImage.FileName);
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images/Animals");
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updatedAnimal.UploadedImage.CopyToAsync(stream);
                }

                updatedAnimal.PictureName = uniqueFileName;
            }
            else
            {
                updatedAnimal.PictureName = "default_no_animal.jpg";
            }

            _repository.InsertAnimal(updatedAnimal);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAnimalData(Animal updatedAnimal)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _repository.GetCategories();
                return View("UpdateAnimal", updatedAnimal);
            }

            if (updatedAnimal.UploadedImage != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(updatedAnimal.UploadedImage.FileName);
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images/Animals");
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updatedAnimal.UploadedImage.CopyToAsync(stream);
                }

                updatedAnimal.PictureName = uniqueFileName;
            }

            _repository.UpdateAnimal(updatedAnimal);

            return RedirectToAction("Index");
        }
    }
}
