#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_and_categories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get; set;}
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(45)]
        public string Name {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public List<Categorization> Products {get; set;} = new List<Categorization>();
    }
}