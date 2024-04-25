using System.ComponentModel.DataAnnotations;

namespace symptomSage.Models
{
    public class SymptomRegister
    {
        [Required(ErrorMessage = "Introduceti Simptomului")]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Simptomul e prea lung!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Introduce-ti descrierea simptomului!")]
        [Display(Name = "Category")]
        [StringLength(20)]
        public string Category { get; set; }
        
    }
}