using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;

namespace PetShopApplication.ViewComponents
{
    public class AnimalFormViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(Animal updatedAnimal)
        {
            return Task.FromResult<IViewComponentResult>(View("_AnimalForm", updatedAnimal));
        }
    }
}
