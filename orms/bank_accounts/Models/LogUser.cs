#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank_accounts.Models
{
    public class LogUser
    {
        [Required]
        [EmailAddress]
        [NotMapped]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Password {get; set;}
    }
}