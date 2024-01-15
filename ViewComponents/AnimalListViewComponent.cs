using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;

namespace PetShopApplication.ViewComponents
{
    public class AnimalListViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(IEnumerable<Animal> animals)
        {
            return Task.FromResult<IViewComponentResult>(View("_AnimalList", animals));
        }
    }
}
