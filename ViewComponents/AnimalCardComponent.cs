using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;

namespace PetShopApplication.ViewComponents
{
    public class AnimalCardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Animal param)
        {
            return View("AnimalCard", param);
        }
    }
}
