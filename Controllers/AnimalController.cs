using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Repositories;

namespace PetShopApplication.Controllers
{
    public class AnimalController : Controller
    {
        private IPetShopRepository _repository;
        public AnimalController(IPetShopRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Details(int animalId)
        {
            return View(_repository.GetAnimalWithComments(animalId));
        }
    }
}
