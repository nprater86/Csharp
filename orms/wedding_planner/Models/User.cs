#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wedding_planner.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}
        [Required]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public List<Attendee> Weddings {get; set;} = new List<Attendee>();
    }
}