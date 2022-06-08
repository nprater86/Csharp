using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace dojo_survey_with_model.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string Name {get; set;}
        [Required]
        public string Location {get; set;}
        [Required]
        public string FaveLanguage {get; set;}
        [MinLength(20, ErrorMessage = "Comments must be at least 20 characters.")]
        public string? Comment {get; set;}
    }
}