using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApplication.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
    }
}
