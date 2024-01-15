using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;

namespace PetShopApplication.ViewComponents
{
    public class AnimalCardViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(Animal animal)
        {
            return Task.FromResult<IViewComponentResult>(View("_AnimalCard", animal));
        }
    }
}
