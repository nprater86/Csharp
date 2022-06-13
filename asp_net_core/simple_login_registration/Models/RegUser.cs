using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace simple_login_registration.Models
{
    public class RegUser
    {
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
        [Required]
        [MinLength(8, ErrorMessage ="Password must be at least 8 characters")]
        [Compare(nameof(Password), ErrorMessage="Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmNewPassword {get; set;}
    }
}