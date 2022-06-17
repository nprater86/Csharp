#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get; set;}
        [Required]
        [Display(Name ="Wedder One")]
        public string WedderOne {get; set;}
        [Required]
        [Display(Name ="Wedder Two")]
        public string WedderTwo {get; set;}
        [Required]
        [FutureDate]
        public DateTime Date {get; set;}
        [Required]
        public string Address {get; set;}
        [Required]
        public int UserId {get; set;}
        public User? Creator {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public List<Attendee> Attendees {get; set;} = new List<Attendee>();

        public class FutureDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime date = (DateTime)value;
                DateTime today = DateTime.Today;
                if(date < today)
                {
                    return new ValidationResult("Date must be a future date");
                }
                return ValidationResult.Success;
            }
        }
    }
}