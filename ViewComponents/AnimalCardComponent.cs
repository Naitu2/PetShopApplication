using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;

namespace PetShopApplication.ViewComponents
{
    public class AnimalCardViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(Animal param)
        {
            return Task.FromResult<IViewComponentResult>(View("AnimalCard", param));
        }
    }
}
