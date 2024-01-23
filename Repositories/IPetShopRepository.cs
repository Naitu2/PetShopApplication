using PetShopApplication.Models;

namespace PetShopApplication.Repositories
{
    public interface IPetShopRepository
    {
        IEnumerable<Animal> GetAnimals(string categoryName = "All Categories");
        IEnumerable<Animal> GetTwoTopAnimalsWithComments();
        void InsertAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(int id);
        Animal? GetAllAnimalInfo(int id);
        Animal? GetAnimalWithComments(int id);
        Animal? GetAnimalWithCategory(int id);
        IEnumerable<Category> GetCategories();
        void AddComment(Comment comment);
    }
}
