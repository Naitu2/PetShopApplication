using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;

namespace PetShopApplication.ViewComponents
{
    public class AnimalCardViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(AnimalCardViewModel animalViewModel)
        {
            return Task.FromResult<IViewComponentResult>(View("_AnimalCard", animalViewModel));
        }
    }

    public class AnimalCardViewModel
    {
        public required Animal Animal { get; set; }
        public bool ShowDeleteButton { get; set; }
        public required string Action { get; set; }
        public required string Controller { get; set; }
    }
}
