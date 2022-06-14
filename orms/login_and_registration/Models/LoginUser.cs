using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace login_and_registration.Models
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}