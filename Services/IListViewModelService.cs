using PetShopApplication.ViewComponents;

namespace PetShopApplication.Services
{
    public interface IListViewModelService
    {
        AnimalListViewModel GetListViewModelData(string section);
    }
}
