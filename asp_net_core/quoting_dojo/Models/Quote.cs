using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace quoting_dojo.Models;

public class Quote
{
    [Required(ErrorMessage ="Name is required")]
    [Display(Name="Name")]
    public string name {get; set;}
    [Required(ErrorMessage ="Quote is required")]
    [Display(Name="Quote")]
    public string quote {get; set;}
}
