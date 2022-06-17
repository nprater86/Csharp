#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_and_categories.Models
{
    public class Categorization
    {
        [Key]
        public int CategorizationId {get; set;}
        [Required]
        public int ProductId {get; set;}
        [Required]
        public int CategoryId {get; set;}
        public Product? Product {get; set;}
        public Category? Category {get; set;}
    }
}