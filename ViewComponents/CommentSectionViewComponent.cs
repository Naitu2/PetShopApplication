using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Models;

namespace PetShopApplication.ViewComponents
{
    public class CommentSectionViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(Animal commentedAnimal)
        {
            return Task.FromResult<IViewComponentResult>(View("_CommentSection", commentedAnimal));
        }
    }
}
