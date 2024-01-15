using PetShopApplication.ViewComponents;

namespace PetShopApplication.Services
{
    public class ListViewModelService : IListViewModelService
    {
        public AnimalListViewModel GetListViewModelData(string section)
        {
            switch (section)
            {
                case "Admin":
                    return new AnimalListViewModel
                    {
                        ShowDeleteButton = true,
                        Action = "Update",
                        Controller = "Admin",
                    };

                case "Catalog":

                default:
                    return new AnimalListViewModel
                    {
                        ShowDeleteButton = false,
                        Action = "Details",
                        Controller = "Catalog",
                    };
            }
        }
    }
}
