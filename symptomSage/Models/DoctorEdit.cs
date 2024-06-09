using System.ComponentModel.DataAnnotations;

namespace symptomSage.Models
{
    public class DoctorEdit
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Introduceti denumirea doctorului")]
        [Display(Name = "Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Medicamentul e prea lung!")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Introduce-ti descrierea simptomului!")]
        [Display(Name = "Desc")]
        [StringLength(700)]
        public string Desc { get; set; }
        
        [Required(ErrorMessage = "Introduce-ti categoria simptomului!")]
        [Display(Name = "Category")]
        [StringLength(90)]
        public string Category { get; set; }
    }
}