#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login_and_registration.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        [MinLength(2, ErrorMessage ="First name must be at least 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}
        [Required]
        [MinLength(2, ErrorMessage ="Last name must be at least 2 characters")]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email {get; set;}
        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password {get; set;}
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmNewPassword {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}