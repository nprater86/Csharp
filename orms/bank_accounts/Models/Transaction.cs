#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace bank_accounts.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {get; set;}
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        [Required]
        public int UserId {get; set;}
        public User? Creator {get; set;}
    }
}