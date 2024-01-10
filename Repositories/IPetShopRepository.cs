using PetShopApplication.Models;

namespace PetShopApplication.Repositories
{
    public interface IPetShopRepository
    {
        IEnumerable<Animal> GetAnimals(string categoryName = "All Categories");
        IEnumerable<Animal> GetTwoTopAnimals();
        void InsertAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(int id);
        Animal? GetAnimalWithComments(int id);
        IEnumerable<Category> GetCategories();
    }
}
