#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace chefs_n_dishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}
        [Required]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}
        [Required]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}
        [Required]
        [PastDate]
        [MustBeEighteen]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth {get; set;}
        public List<Dish> CreatedDishes {get; set;} = new List<Dish>();
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }

    public class MustBeEighteenAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //unbox value since it will be a DateTime
            DateTime birthday = (DateTime)value;

            //find age
            //save today's date
            var today = DateTime.Today;
            //calculate the age
            int age = today.Year - birthday.Year;
            //go back to the year in which the person was born in case of a leap year
            if (birthday > today.AddYears(-age)) age--;

            if(age < 18)
            {
                return new ValidationResult("Chef must be older than 18");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }

    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //unbox value since it will be a DateTime
            DateTime enteredDate = (DateTime)value;

            var today = DateTime.Today;

            if(today < enteredDate)
            {
                return new ValidationResult("Date of Birth cannot be a future date");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}