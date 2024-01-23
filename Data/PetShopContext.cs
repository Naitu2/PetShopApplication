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
                new Category { Id = 4, Name = "Reptiles" },
                new Category { Id = 5, Name = "Rabbits" }
            );

            modelBuilder.Entity<Animal>().HasData(
    new Animal
    {
        Id = 1,
        Name = "Whiskers",
        Age = 2,
        PictureName = "whiskers.jpg",
        Description = "A fluffy grey cat with sparkling green eyes, known for its playful nature and love for cuddles.",
        CategoryId = 1
    },
    new Animal
    {
        Id = 2,
        Name = "Fido",
        Age = 3,
        PictureName = "fido.jpeg",
        Description = "Meet Fido, a 3-year-old charming brown dog, capturing hearts with his playful antics and loyal companionship." +
        " His expressive eyes and friendly demeanor make every encounter delightful. A fan of long, leisurely walks," +
        " Fido thrives in the company of children, showcasing his gentle nature.",
        CategoryId = 2
    },
    new Animal
    {
        Id = 3,
        Name = "Paws",
        Age = 1,
        PictureName = "paws.jpg",
        Description = "A playful kitten with a mischievous streak, loves climbing and exploring new spaces.",
        CategoryId = 1
    },
    new Animal
    {
        Id = 4,
        Name = "Chirpy",
        Age = 1,
        PictureName = "chirpy.jpg",
        Description = "A cheerful little birdy with bright feathers and an enchanting song that brings joy to anyone who hears it.",
        CategoryId = 3
    },
    new Animal
    {
        Id = 5,
        Name = "Tweety",
        Age = 2,
        PictureName = "tweety.jpg",
        Description = "A canary with a sweet song, known for its vibrant yellow color and energetic personality.",
        CategoryId = 3
    },
    new Animal
    {
        Id = 6,
        Name = "Scales",
        Age = 4,
        PictureName = "scales.png",
        Description = "A calm and collected iguana with striking green scales, enjoys basking in the sun and has a gentle nature.",
        CategoryId = 4
    },
    new Animal
    {
        Id = 7,
        Name = "Slither",
        Age = 2,
        PictureName = "slither.jpg",
        Description = "A curious corn snake with a distinctive pattern, known for its inquisitive behavior and ease of handling.",
        CategoryId = 4
    },
    new Animal
    {
        Id = 8,
        Name = "Bella",
        Age = 5,
        PictureName = "bella.jpg",
        Description = "Bella is a gentle and friendly rabbit known for her soft fur and curious nature. She loves hopping around and exploring her surroundings, always up for a cuddle or a playful chase.",
        CategoryId = 5
    },
new Animal
{
    Id = 9,
    Name = "Smokey",
    Age = 2,
    PictureName = "smokey.jpg",
    Description = "Smokey is a charming gray rabbit with a soft, fluffy coat. Known for her calm demeanor, she enjoys quiet moments and gentle handling. Her soothing presence makes her a favorite among those who seek a peaceful companion.",
    CategoryId = 5
}
);

            modelBuilder.Entity<Comment>().HasData(
    new Comment { Id = 1, AnimalId = 1, Content = "So adorable!" },
    new Comment { Id = 2, AnimalId = 2, Content = "Really friendly." },
    new Comment { Id = 3, AnimalId = 4, Content = "Loves to sing." },
    new Comment { Id = 4, AnimalId = 6, Content = "Very majestic." },
    new Comment { Id = 5, AnimalId = 1, Content = "So playful and cute." },
    new Comment { Id = 6, AnimalId = 1, Content = "Loves to be petted." },
    new Comment { Id = 7, AnimalId = 1, Content = "The perfect companion." },
    new Comment { Id = 8, AnimalId = 1, Content = "Always curious and fun." },
    new Comment { Id = 9, AnimalId = 2, Content = "Great with kids." },
    new Comment { Id = 10, AnimalId = 2, Content = "Very loyal and protective." },
    new Comment { Id = 11, AnimalId = 2, Content = "Enjoys long walks in the park." },
    new Comment { Id = 12, AnimalId = 2, Content = "Has a cheerful and energetic spirit." },
    new Comment { Id = 13, AnimalId = 3, Content = "Incredibly adorable and playful." },
    new Comment { Id = 14, AnimalId = 5, Content = "Bright and beautiful, with an enchanting voice." },
    new Comment { Id = 15, AnimalId = 7, Content = "Fascinating to watch and very friendly." },
    new Comment { Id = 16, AnimalId = 2, Content = "I'm allergic, but ready to take pills every day for that one." },
    new Comment { Id = 17, AnimalId = 4, Content = "Doesn't look so smart." }
    );
        }
    }
}
