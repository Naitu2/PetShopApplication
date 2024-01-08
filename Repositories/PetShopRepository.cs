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

        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals!;
        }

        public IEnumerable<Animal> GetTwoTopAnimals()
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
                var entry = _context.Entry(existingAnimal);
                foreach (var property in entry.Metadata.GetProperties())
                {
                    var proposedValue = entry.CurrentValues.GetValue<object>(property.Name);
                    var existingValue = entry.OriginalValues.GetValue<object>(property.Name);

                    if (proposedValue != null && !Equals(existingValue, proposedValue))
                    {
                        entry.Property(property.Name).CurrentValue = proposedValue;
                    }
                }

                //entry.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
