using System.ComponentModel.DataAnnotations;

namespace PetShopApplication.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category:")]
        public string? Name { get; set; }
    }
}
