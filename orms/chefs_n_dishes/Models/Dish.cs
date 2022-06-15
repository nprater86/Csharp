#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace chefs_n_dishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Calories must be greater than 0")]
        public int Calories {get; set;}
        [Required]
        [Range(1,5,ErrorMessage ="Please select Tastiness level")]
        public int Tastiness {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Please choose a chef")]
        public int ChefId {get; set;}
        public Chef? Creator {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}