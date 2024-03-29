﻿using Microsoft.EntityFrameworkCore;
using PetShopApplication.Data;
using PetShopApplication.Models;

namespace PetShopApplication.Repositories
{
    public class PetShopRepository : IPetShopRepository
    {
        private PetShopContext _context;

        public PetShopRepository(PetShopContext context)
        {
            _context = context;
        }

        public void DeleteAnimal(int id)
        {
            var animal = _context.Animals!.Single(m => m.Id == id);
            _context.Animals!.Remove(animal);
            _context.SaveChanges();
        }

        public IEnumerable<Animal> GetAnimals(string categoryName)
        {
            IQueryable<Animal> query = _context.Animals!;

            if (!string.IsNullOrWhiteSpace(categoryName) && categoryName != "All Categories")
            {
                query = query.Join(_context.Categories!,
                                   animal => animal.CategoryId,
                                   category => category.Id,
                                   (animal, category) => new { Animal = animal, Category = category })
                             .Where(ac => ac.Category.Name == categoryName)
                             .Select(ac => ac.Animal);
            }

            return query.ToList();
        }

        public IEnumerable<Animal> GetTwoTopAnimalsWithComments()
        {
            var topAnimals = _context.Animals!
                .Include(a => a.Comments)
                .AsEnumerable()
                .OrderByDescending(a => a.Comments!.Count)
                .Take(2)
                .ToList();

            return topAnimals;
        }

        public void InsertAnimal(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }

        public void UpdateAnimal(Animal updatedAnimal)
        {
            var existingAnimal = _context.Animals!.FirstOrDefault(a => a.Id == updatedAnimal.Id);
            if (existingAnimal != null)
            {
                _context.Entry(existingAnimal).CurrentValues.SetValues(updatedAnimal);

                _context.SaveChanges();
            }
        }

        public Animal? GetAllAnimalInfo(int id)
        {
            return _context!.Animals!
                           .Include(a => a.Comments)
                           .Include(a => a.Category)
                           .FirstOrDefault(a => a.Id == id);
        }

        public Animal? GetAnimalWithComments(int id)
        {
            return _context!.Animals!
                           .Include(a => a.Comments)
                           .FirstOrDefault(a => a.Id == id);
        }

        public Animal? GetAnimalWithCategory(int id)
        {
            return _context!.Animals!
                           .Include(a => a.Category)
                           .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories!.ToList();
        }

        public void AddComment(Comment comment)
        {
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }
    }
}
