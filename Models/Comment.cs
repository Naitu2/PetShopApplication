using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApplication.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Content cannot be empty.")]
        [StringLength(300, ErrorMessage = "Content cannot be more than 300 characters long.")]
        public string? Content { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public virtual Animal? Animal { get; set; }
    }
}
