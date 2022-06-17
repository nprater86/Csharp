#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_and_categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(45)]
        public string Name {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public decimal Price {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public List<Categorization> Categories {get; set;} = new List<Categorization>();
    }
}