using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApplication.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(30, ErrorMessage = "Name cannot be more than 30 characters long.")]
        public string? Name { get; set; }

        [Display(Name = "Age:")]
        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150.")]
        public int Age { get; set; }

        [RegularExpression("^.*\\.(jpg|jpeg|png)$", ErrorMessage = "The picture name must end with .jpg, .jpeg, or .png.")]
        public string? PictureName { get; set; }

        [Display(Name = "Description:")]
        [DataType(DataType.MultilineText)]
        [StringLength(300, ErrorMessage = "Description cannot be more than 300 characters long.")]
        public string? Description { get; set; }

        [ForeignKey("Category")]
        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
