using Microsoft.EntityFrameworkCore;
using PetShopApplication.Models;

namespace PetShopApplication.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Comment>? Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Cats" },
                new Category { Id = 2, Name = "Dogs" },
                new Category { Id = 3, Name = "Birds" },
                new Category { Id = 4, Name = "Reptiles" }
            );

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Whiskers", Age = 2, PictureName = "whiskers.jpg", Description = "A fluffy grey cat", CategoryId = 1 },
                new Animal { Id = 2, Name = "Fido", Age = 3, PictureName = "fido.jpg", Description = "A playful brown dog", CategoryId = 2 },
                new Animal { Id = 3, Name = "Paws", Age = 1, PictureName = "paws.jpg", Description = "A playful kitten", CategoryId = 1 },
                new Animal { Id = 4, Name = "Chirpy", Age = 1, PictureName = "chirpy.jpg", Description = "A cheerful little parrot", CategoryId = 3 },
                new Animal { Id = 5, Name = "Tweety", Age = 2, PictureName = "tweety.jpg", Description = "A canary with a sweet song", CategoryId = 3 },
                new Animal { Id = 6, Name = "Scales", Age = 4, PictureName = "scales.jpg", Description = "A calm and collected iguana", CategoryId = 4 },
                new Animal { Id = 7, Name = "Slither", Age = 2, PictureName = "slither.jpg", Description = "A curious corn snake", CategoryId = 4 }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, AnimalId = 1, Content = "So adorable!" },
                new Comment { Id = 2, AnimalId = 2, Content = "Really friendly." },
                new Comment { Id = 3, AnimalId = 4, Content = "Loves to sing." },
                new Comment { Id = 4, AnimalId = 6, Content = "Very majestic." }
            );

        }
    }
}
