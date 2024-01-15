using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;

namespace PetShopApplication.ViewComponents
{
    public class AnimalListViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(AnimalListViewModel animalListViewModel)
        {
            return Task.FromResult<IViewComponentResult>(View("_AnimalList", animalListViewModel));
        }
    }

    public class AnimalListViewModel
    {
        public IEnumerable<Animal>? Animals { get; set; }
        public bool ShowDeleteButton { get; set; }
        public required string Action { get; set; }
        public required string Controller { get; set; }
        public string? SelectedCategory { get; set; }
    }
}
