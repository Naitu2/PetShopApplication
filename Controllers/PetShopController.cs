﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Catalog()
        {
            ViewBag.Categories = _repository.GetCategories().Select(c => c.Name).ToList();
            return View(_repository.GetAnimals());
        }
        public IActionResult Admin()
        {
            return View();
        }
    }
}
