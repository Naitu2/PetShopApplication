using Microsoft.AspNetCore.Mvc;

namespace PetShopApplication.ViewComponents
{
    public class CommentSectionViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View("_CommentSection"));
        }
    }
}
