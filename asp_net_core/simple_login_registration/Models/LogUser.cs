using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace simple_login_registration.Models
{
    public class LogUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}