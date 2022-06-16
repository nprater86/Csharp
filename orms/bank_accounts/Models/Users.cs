#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank_accounts.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        public string FirstName {get; set;}
        [Required]
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
        public List<Transaction> UserTransactions {get; set;} = new List<Transaction>();

        public decimal balance()
        {
            decimal balance = 0.00m;
            foreach(Transaction t in UserTransactions)
            {
                balance += t.Amount;
            }
            return balance;
        }
    }
}