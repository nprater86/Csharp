using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace form_submission.Models
{
    public class User
    {
        [Required]
        [MinLength(4, ErrorMessage = "First name must be at least 4 characters long")]
        public string FirstName {get; set;}
        [Required]
        [MinLength(4, ErrorMessage = "Last name must be at least 4 characters long")]
        public string LastName {get; set;}
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Age {get; set;}
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}