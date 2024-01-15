using System.ComponentModel.DataAnnotations;

namespace PetShopApplication.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category Name:")]
        public string? Name { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }
    }
}
