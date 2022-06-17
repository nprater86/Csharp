#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
    public class LogUser
    {
        [Required]
        [Display(Name ="Email")]
        public string LogEmail {get; set;}
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string LogPassword {get; set;}
    }
}